using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{

    private bool gameEnded=false;

    public GameObject gameOverUI;
    public Text txtWinner;
    public Text txtNbRound;
    public Text txtChronoFinal;

    // Update is called once per frame
    void Update()
    {
        if(gameEnded==true) return;
        if(life.getLives()<=0)
        {
            attackWin();
        }
        if((round.getRoundNumber()>round.getLastRound())|| (chrono.getCurrentTime()>chrono.getEndTime()))
        {
            defenseWin();
        }
    }

    void defenseWin()
    {
        gameEnded=true;
        chrono.StopChrono();
        gameOverUI.SetActive(true);
        txtWinner.text="Le défenseur a gagné !";
        txtNbRound.text=round.getRoundNumber().ToString()+" manches";
        txtChronoFinal.text=(chrono.getCurrentTime()/60).ToString()+"m "+ (chrono.getCurrentTime()%60).ToString()+"s";
    }

    void attackWin()
    {
        gameEnded=true;
        Debug.Log("L'attaquant a gagné. Le défenseur a perdu.");
        chrono.StopChrono();
        gameOverUI.SetActive(true);
        txtWinner.text="L'attaquant a gagné !";
        txtNbRound.text=round.getRoundNumber().ToString()+" manches";
        txtChronoFinal.text=(chrono.getCurrentTime()/60).ToString()+"m "+ (chrono.getCurrentTime()%60).ToString()+"s";
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("Scenes/GameMenu");
    }
}
