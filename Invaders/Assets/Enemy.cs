using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public GameController myGameController;
	public EnemySpawner myEnemySpawner;

	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		myGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		myEnemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	void Update () 
	{
		this.transform.position = Vector3.Lerp (this.transform.position, player.transform.position, Time.deltaTime/5);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			myGameController.health -= 1;	
			myEnemySpawner.enemyCount -=1;
			myEnemySpawner.enemies.Remove(this.gameObject);
			Destroy(this.gameObject);
		}
	}
}
