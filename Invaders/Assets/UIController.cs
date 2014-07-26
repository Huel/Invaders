using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	
	public GameController myGameController;
	public GameObject myPlayer;
	public EnemySpawner myEnemySpawner;
	public Text scoreText;
	public Text messageText;
	public Slider healthSlider;
	public Image incomingArrow;


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

		//arrow
		Vector3 nearest = Vector3.zero;
		foreach (GameObject enemy in myEnemySpawner.enemies)
		{
			Vector3 aDistance = enemy.transform.position -  incomingArrow.transform.position;

			if(nearest == Vector3.zero 
			   || aDistance.magnitude < nearest.magnitude)
			{
				nearest = aDistance;
			}
		}
		if (nearest == Vector3.zero)
						nearest = Vector3.right;
		//IncomingWarning (nearest);
	}

	public void IncomingWarning(Vector3 direction)
	{

		float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		incomingArrow.rectTransform.localEulerAngles= new Vector3(0f, 0f, rot-90f);

	}
}
