using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public GameController myGameController;
	public EnemySpawner myEnemySpawner;

	private float totalBulletDur;

	void Start ()
	{
		myGameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
		myEnemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	void Update () 
	{
		totalBulletDur += Time.deltaTime;

		//destroy bullet gameobject after some time
		if(totalBulletDur > 5)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "enemy")
		{
			KillEnemy killEnemy = collider.GetComponent<KillEnemy>();
			if(!killEnemy.kill)
				myEnemySpawner.audio.Play();
			myEnemySpawner.enemyCount -=1;
			myEnemySpawner.enemies.Remove(collider.gameObject);
			myGameController.score += 100;
			collider.GetComponent<KillEnemy>().Kill();
			Destroy(this.gameObject);
		}
	}
}
