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
    public Transform directionPivot;


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
		Vector3 nearestEney = Vector3.zero;
		Vector3 nearest = Vector3.zero;
		foreach (GameObject enemy in myEnemySpawner.enemies)
		{

            if (nearestEney == Vector3.zero
               || (directionPivot.position - enemy.transform.position).magnitude < (directionPivot.position - nearestEney).magnitude)
            {
                nearestEney = enemy.transform.position;
                nearest = enemy.transform.position - incomingArrow.transform.transform.position;
                
			}
		}
        Debug.DrawLine(directionPivot.position, incomingArrow.transform.transform.position + nearest);
        Debug.DrawLine(directionPivot.position, incomingArrow.transform.transform.position);
        Debug.DrawLine(incomingArrow.transform.position, incomingArrow.transform.transform.position + nearest);

        IncomingWarning(nearest);
		
	}

	public void IncomingWarning(Vector3 direction)
	{
        direction = transform.InverseTransformDirection(direction);
		float rot = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
	    float dir = Vector3.Dot(Vector3.forward, direction.normalized);
	    Color color = incomingArrow.color;
	    color.a = Mathf.Log(dir, 0.5f);
        Debug.Log(color.a);
	    incomingArrow.color = color;
		incomingArrow.rectTransform.localEulerAngles= new Vector3(0f, 0f, rot-90f);

	}
}
