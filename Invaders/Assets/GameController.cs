using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public int health;
	public int gameState; //0 = pause, 1 = running, 2 = game over
	public HitFeedback hitFeedback;

	void Start ()
	{
		gameState = 1;
		score = 0;	
		health = 10;
	}
	
	void Update () 
	{
		if(health == 0)
		{
			gameState = 2;
		}
	}
}
