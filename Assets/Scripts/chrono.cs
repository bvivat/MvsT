using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class chrono : MonoBehaviour
{
    private static int startTime = 0;
    private static int currentTime = 0;
    private static int endTime=1200;
    private static bool chronoOn = false;

    public Text chronoText;

    // Start is called before the first frame update
    void Start()
    {
         StartChrono();
    }
    

    // Update is called once per frame
    void Update()
    {
        if(chronoOn)
        {
            currentTime = Convert.ToInt32(Time.time) - startTime;
            if(currentTime<60) chronoText.text=currentTime.ToString()+"s";
            else chronoText.text=(currentTime/60).ToString()+"m "+ (currentTime%60).ToString()+"s";
        }
    }

    public static void StartChrono()
    {
        startTime = Convert.ToInt32(Time.time);
        chronoOn = true;
    }

    public static void StopChrono()
    {
        chronoOn = false;
    }

    public static void RestartChrono()
    {
        chronoOn = true;
    }

    public static int getCurrentTime()
    {
        return currentTime;
    }

    public static int getEndTime()
    {
        return endTime;
    }

    public static void setEndTime(int et)
    {
        endTime=et;
    }
}
