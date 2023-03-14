using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	public GameObject gameMenuUI;
	public GameObject gameStartUI;
	public GameObject gameCreditUI;
	public GameObject gameRulesUI;

	public InputField inputNbRound;
	public InputField inputEndTime;

	public Outline[] contours;
	private string sceneToLoad = "Scenes/Forest";
	private Dictionary<int, string> scenes = new Dictionary<int, string>()
	{
			{ 0, "Scenes/Forest" },
			{ 1,"Scenes/Desert" },
			{ 2, "Scenes/Winter" }
	};
	

	// Start is called before the first frame update
	void Start()
	{
		gameMenuUI.SetActive(true);
		gameStartUI.SetActive(false);
		gameCreditUI.SetActive(false);
		gameRulesUI.SetActive(false);

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void MenuToStart()
	{
		gameMenuUI.SetActive(false);
		gameStartUI.SetActive(true);
	}

	public void StartToMenu()
	{
		gameMenuUI.SetActive(true);
		gameStartUI.SetActive(false);
	}

	public void MenuToCredit()
	{
		gameMenuUI.SetActive(false);
		gameCreditUI.SetActive(true);
	}

	public void CreditToMenu()
	{
		gameMenuUI.SetActive(true);
		gameCreditUI.SetActive(false);
	}

	public void MenuToRules()
	{
		gameMenuUI.SetActive(false);
		gameRulesUI.SetActive(true);
	}

	public void RulesToMenu()
	{
		gameMenuUI.SetActive(true);
		gameRulesUI.SetActive(false);
	}

	public void Quit()
	{
		Debug.Log("QUIT");
		Application.Quit();
	}

	public void selectMap(int numMap)
	{
		sceneToLoad = scenes[numMap];
		foreach (var c in contours)
		{
			c.effectColor = Color.black;
		}
		contours[numMap].effectColor = Color.red;

	}

	public void startGame()
	{
		int nbRound = int.Parse(inputNbRound.text);
		round.setLastRound(nbRound);
		int endTime = int.Parse(inputEndTime.text);
		endTime *= 60;
		chrono.setEndTime(endTime);

		SceneManager.LoadScene(sceneToLoad);
	}


}
