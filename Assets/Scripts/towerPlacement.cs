using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerPlacement : MonoBehaviour
{
	Camera cam;

	GameObject tower;
	int price;

	GameObject instance;

	public collisionDetect col;
	Color c = Color.green;

	public AudioSource audio;
	public AudioClip clip;


	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
	}

	// Update is called once per frame
	void Update()
	{
		if (tower != null)
		{
			if (instance == null)
			{
				instance = Instantiate(tower);
				col = instance.GetComponentInChildren<collisionDetect>();
				instance.GetComponent<turret>().enabled = false;

			}
			else
			{
				MoveObject();
				if (col.isColliding())
				{
					updateColor(Color.red);
				}
				else
				{
					updateColor(Color.green);
					if (Input.GetButton("Tower"))
					{
						updateColor(Color.white);
						instance.GetComponent<turret>().enabled = true;
						clearTower();
						money.subMoneyDefense(price);
						audio.PlayOneShot(clip);
					}
				}
			}


			//Destroy(instance);
		}


	}
	void updateColor(Color c)
	{
		if (instance != null)
		{
			foreach (Renderer r in instance.GetComponentsInChildren<Renderer>())
			{
				r.material.color = c;
			}
		}

	}
	void MoveObject()
	{
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red);

		if (Physics.Raycast(ray, out hit))
		{
			instance.transform.position = hit.point;
			instance.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
		}
	}

	public void putTower(GameObject t)
	{
		Debug.Log("Setting tower...");
		price = t.GetComponent<turret>().getPrice();
		if (money.requestBuyTower(price))
		{
			tower = t;
		}
		
	}
	public void clearTower()
	{
		Debug.Log("Clearing tower...");
		tower = null;
		instance = null;
	}


}
