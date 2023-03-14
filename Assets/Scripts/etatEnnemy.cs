using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class etatEnnemy : MonoBehaviour
{
    public float hp=100;
    public int moneyOnCreate;
    public int moneyOnDeath;

    // Start is called before the first frame update
    void Start()
    {
        money.subMoneyAttack(moneyOnCreate);
    }

    void onKill()
    {
        money.addMoneyDefense(moneyOnDeath);
        Destroy(gameObject);
    }

    void OnDestroy()
    {
        Spawner.decNbEnemyOnMap();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

	public void takeDamage(float damage)
	{
		hp -= damage;
		if (hp <= 0) onKill();
	}
}
