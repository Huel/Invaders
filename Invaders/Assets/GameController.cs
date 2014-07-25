using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public int score;
	public int health;
	public int gameState; //0 = pause, 1 = running, 2 = game over

	void Start ()
	{
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
