using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	
	public GameController myGameController;
	public Text scoreText;
	public Slider healthSlider;

	void Start () 
	{
	
	}

	void Update ()
	{
		scoreText.text = "Score: " + myGameController.score;
		healthSlider.value = myGameController.health;
	}
}
