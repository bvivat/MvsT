using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
	private bool colliding;
	// Start is called before the first frame update

	public bool isColliding()
	{
		return colliding;
	}
	void OnTriggerEnter(Collider other)
	{
		//Debug.Log("Collision enter " + other.gameObject.name);
	}
	void OnTriggerStay(Collider other)
	{
		//Debug.Log("Collision stay "+other.gameObject.name);
		if (other.tag != "Terrain")
		{
			colliding = true;
		}
	}
	void OnTriggerExit(Collider other)
	{
		//Debug.Log("Collision out " + other.gameObject.name);
		colliding = false;
	}
}
