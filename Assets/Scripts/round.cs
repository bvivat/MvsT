using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class round : MonoBehaviour
{
    private static int roundNumber;
    private int startRound =1;
    private static int lastRound=30;

    public Text roundLabel;

    private static int roundMoneyAttack;
    private int startMoneyAttack=200;
    private static int roundMoneyDefense;
    private int startMoneyDefense=400;

    // Start is called before the first frame update
    void Start()
    {
        roundNumber=startRound;
        roundMoneyAttack=startMoneyAttack;
        roundMoneyDefense=startMoneyDefense;
    }

    public static void nextRound()
    {
        roundNumber++;
        double tmpAttack=roundMoneyAttack*1.15;
        roundMoneyAttack=Convert.ToInt32(tmpAttack);
        money.addMoneyAttack(roundMoneyAttack);
        money.addMoneyDefense(200);
    }

    // Update is called once per frame
    void Update()
    {
        roundLabel.text= "Manche " + roundNumber.ToString();
    }

    public static int getLastRound()
    {
        return lastRound;
    }

    public static void setLastRound(int lr)
    {
        lastRound =lr;
    }

    public static int getRoundNumber()
    {
        return roundNumber;
    }

}
