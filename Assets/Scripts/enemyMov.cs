using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMov : MonoBehaviour
{
	Transform target;
	NavMeshAgent nav;
	// Start is called before the first frame update
	void Awake()
    {
		nav = GetComponent<NavMeshAgent>();
		//move(direction);
		target = FindObjectOfType<onEnnemyArrival>().gameObject.transform;
		
		nav.SetDestination(target.position);
	}

    // Update is called once per frame
    void FixedUpdate()
    {
		//Vector3 direction = target.position - transform.position;
		////move(direction);
		//nav.SetDestination(target.position);
    }

	void move(Vector3 dir)
	{
		//rb.MovePosition(transform.position + dir * 2 * Time.deltaTime);
	}
}
