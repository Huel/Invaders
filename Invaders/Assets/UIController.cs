using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {
	
	public GameController myGameController;

	void Start () {
	
	}

	void OnGui() 
	{
		GUI.Label(new Rect(Screen.width/2,Screen.height/2,300,300),"Score: "+myGameController.score);
	}
}
