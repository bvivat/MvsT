using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnnemyArrival : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider collision)
	{
		Debug.Log("collision :" + collision.gameObject.tag);
		if (collision.gameObject.tag=="Enemy")
		{
			Destroy(collision.gameObject);
            life.subLives(10);
		}
	}
}
