using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] enemy;

	public Transform[] spawnPoints;
	int spawningEnemyNumber;

	static int nbEnemyOnMap=0;
	
	private static Dictionary<int, int> mapPriceEnemy = new Dictionary<int, int>();
	private static int minPrice=80;


	// Start is called before the first frame update
	void Start()
	{
		mapPriceEnemy.Add(1,80);
		mapPriceEnemy.Add(2,100);
		mapPriceEnemy.Add(3,1000);

	}
	void Update()
	{
		//Debug.Log("NB ENEMY " + nbEnemyOnMap);
		if((money.getMoneyAttack()<minPrice)&&nbEnemyOnMap==0) round.nextRound();

		for (int i = 0; i < enemy.Length; i++)
		{
		
			if (Input.GetButtonDown(i.ToString()))
			{
				Debug.Log("If" + i);
				spawningEnemyNumber = i;
				Invoke("spawn", 0.5f);
			}
		}

	}
	void spawn()
	{
		if(money.requestBuy(mapPriceEnemy[spawningEnemyNumber+1]))
		{
			int spawnPoint = Random.Range(0, spawnPoints.Length);
			Instantiate(enemy[spawningEnemyNumber], spawnPoints[spawnPoint].position, spawnPoints[spawnPoint].rotation);
			spawningEnemyNumber = -1;
			nbEnemyOnMap++;
		}
	}

	public static int getNbEnemyOnMap() 
	{
		return nbEnemyOnMap;
	}

	public static void decNbEnemyOnMap()
	{
		nbEnemyOnMap--;
	}
}
