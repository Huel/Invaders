using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	
	public GameController myGameController;
	public Text scoreText;
	public Text messageText;
	public Slider healthSlider;

	void Start () 
	{
		messageText.enabled = false;
		healthSlider.value = myGameController.health;
		healthSlider.maxValue = myGameController.health;
	}

	void Update ()
	{

		switch(myGameController.gameState)
		{
		case 0:
			break;
		case 1:
			Time.timeScale = 1;
			if(!scoreText.enabled)
			{
				scoreText.enabled = true;
			}
			if(!healthSlider.enabled)
			{
				healthSlider.enabled = true;
			}
			UpdateUI();
			break;
		//GAME OVER
		case 2:
			UpdateUI();
			messageText.text = "GAME OVER\nPress any button to retry!";
			messageText.enabled = true;
			Time.timeScale = 0;
			if(Input.anyKeyDown)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			break;
		case 3:
			break;
		}
	}

	void UpdateUI()
	{
		scoreText.text = "Score: " + myGameController.score;
		healthSlider.value = myGameController.health;
	}

	public void IncomingWarning()
	{
	}
}
