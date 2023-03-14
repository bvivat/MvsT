using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etatEnnemyDragon : etatEnnemy
{
 
    // Update is called once per frame
    protected override void Update()
    {
		
		if (hp < 500)
		{
			GetComponent<Animator>().SetTrigger("IsRun");
			GetComponent<UnityEngine.AI.NavMeshAgent>().speed = 9;
		}
	}
}
