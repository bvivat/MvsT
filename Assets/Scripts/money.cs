using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    private static int moneyDefense;
    private int startMoneyDefense=400;
    private static int moneyAttack;
    private int startMoneyAttack=200;

    public Text moneyAttackLabel;
    public Text moneyDefenseLabel;


    public void Start()
    {
        moneyDefense=startMoneyDefense;
        moneyAttack=startMoneyAttack;
    }

    void Update()
    {
        moneyAttackLabel.text= moneyAttack.ToString();
        moneyDefenseLabel.text= moneyDefense.ToString();
    }

    static public bool requestBuy(int price)
    {
        return moneyAttack>=price;
    }
	static public bool requestBuyTower(int price)
	{
		return moneyDefense >= price;
	}

	static public int getMoneyDefense()
    {
        return moneyDefense;
    }

    static public void setMoneyDefense(int money)
    {
        moneyDefense=money;
    }

    static public void addMoneyDefense(int money)
    {
        moneyDefense+=money;
    }

    static public void subMoneyDefense(int money)
    {
        moneyDefense-=money;
    }

    static public int getMoneyAttack()
    {
        return moneyAttack;
    }

    static public void setMoneyAttack(int money)
    {
        moneyDefense=money;
    }

    static public void addMoneyAttack(int money)
    {
        moneyAttack+=money;
    }

    static public void subMoneyAttack(int money)
    {
        moneyAttack-=money;
    }

}
