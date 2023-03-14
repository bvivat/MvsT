using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life : MonoBehaviour
{
    private static int lives;
    private int startLives=100;

    public Text livesText;

    // Start is called before the first frame update
    void Start()
    {
        lives=startLives;

    }

    // Update is called once per frame
    void Update()
    {
        livesText.text= lives.ToString();
    }

    static public int getLives()
    {
        return lives;
    }

    static public void subLives(int sub)
    {
        lives-=sub;
    }





}
