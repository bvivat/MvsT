using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tirer : MonoBehaviour
{

	public GameObject balle;
	public float bulletSpeed;
	Ray shootRay;
	RaycastHit hit;
	LineRenderer shotLine;
	public float displayTime;
	public float fireRate;
	float lastShot = 0;
	public float range;
	public float damage;
	// Start is called before the first frame update
	void Awake()
	{
		//balle = GetComponentInChildren<GameObject>();
		shotLine = GetComponent<LineRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetButton("Fire1") && Time.time > lastShot + fireRate)
		{
			shoot();
		}

		if (Time.time > lastShot + displayTime)
		{
			shotLine.enabled = false;
		}

	}

	void shoot()
	{
		
		shootRay.origin = transform.position;
		shootRay.direction = transform.up;

		shotLine.SetPosition(0, transform.position);

		if (Physics.Raycast(shootRay, out hit, range))
		{
			Debug.Log("hit!"+ hit.transform.name);
			etatEnnemy enemy = hit.transform.GetComponent<etatEnnemy>();
			if (enemy!=null)
			{
				enemy.takeDamage(damage);
			}
			shotLine.SetPosition(1, hit.point);
		}
		else
		{
			shotLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
		shotLine.enabled = true;

		lastShot = Time.time;
	}
}
