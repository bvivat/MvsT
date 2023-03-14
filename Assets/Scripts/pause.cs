using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject gamePauseUI;
    public Text txtNbRound;
    public Text txtChronoFinal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }
        if(isPaused)
        {
                Time.timeScale=0;
                chrono.StopChrono();
                gamePauseUI.SetActive(true);
                txtNbRound.text=" Manche " + round.getRoundNumber().ToString();
                txtChronoFinal.text=(chrono.getCurrentTime()/60).ToString()+"m "+ (chrono.getCurrentTime()%60).ToString()+"s";

        }
        else
        {
                Time.timeScale=1;
                gamePauseUI.SetActive(false);
                chrono.RestartChrono();
        }
    }

public void setPause()
{
    isPaused=true;
}

public void StopPause()
{
    isPaused=false;
}

}