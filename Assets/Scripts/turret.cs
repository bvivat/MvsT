using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
	public GameObject target;
	public float range = 10f;
	public int damagePerHit;
	public float shootingFrequency;
	Ray shootRay;
	RaycastHit hit;
	LineRenderer shotLine;
	public float displayTime;
	float lastShot = 0;
	Transform startingPoint;
	int layer_mask;

	public int price;
	public static int minPrice = 100; // Utilite ?

	GameObject nearestEnemy;
	GameObject[] enemies;

	public string enemyTag = "Enemy";

	public Transform partToRotate;

	private AudioSource mAudioSrc;


	// Start is called before the first frame update
	void Start()
	{
		InvokeRepeating("UpdateTarget", 0, 0.5f);
		shotLine = GetComponentInChildren<LineRenderer>();
		startingPoint = GetComponentInChildren<FindMe>().gameObject.transform;
		layer_mask = LayerMask.GetMask("GroundEnemies");
		mAudioSrc =  GetComponent<AudioSource>();
	}

	void UpdateTarget()
	{
		enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		nearestEnemy = null;


		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}

		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy;
		}
		else
		{
			target = null;
		}
	}

	void shoot()
	{
		shootRay.origin = startingPoint.position;
		shootRay.direction = startingPoint.forward;

		shotLine.SetPosition(0, startingPoint.position);

		

		if (Physics.Raycast(shootRay, out hit, range, layer_mask, QueryTriggerInteraction.Collide))
		{
			//Debug.Log("hit!" + hit.transform.name);
			etatEnnemy enemy = hit.transform.GetComponent<etatEnnemy>();
			if (enemy != null)
			{
				mAudioSrc.Play();
				enemy.takeDamage(damagePerHit);
			}
			shotLine.SetPosition(1, hit.point);
		}
		else
		{
			//shotLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
		shotLine.enabled = true;

		lastShot = Time.time;
	}

	// Update is called once per frame
	void Update()
	{
		if (target != null)
		{

			Vector3 dir = target.transform.position - transform.position;
			Quaternion lookRotation = Quaternion.LookRotation(dir);
			Vector3 rotation = lookRotation.eulerAngles;
			partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

			if (Time.time > lastShot + shootingFrequency)
			{
				shoot();
			}


		}
		if (Time.time > lastShot + displayTime)
		{
			shotLine.enabled = false;
		}
	}

	public int getPrice()
	{
		return price;
	}

}
