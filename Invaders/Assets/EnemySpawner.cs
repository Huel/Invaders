using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public int maxCount; 	// max enemies spawned by spawner
	public int spawnRate; 	//spawns in sec
	public int range;		// positional range
	public GameObject enemyPrefab;
	public GameObject player;
	public int enemyCount;


	private float timerCount;

	void Start () 
	{
		maxCount = 5;
		spawnRate = 1;
		range = 500;
		timerCount = 0.0f;
	}
	
	void Update ()
	{
		timerCount += Time.deltaTime;
		Debug.Log("timerCount: " + timerCount);
		if (timerCount > spawnRate && enemyCount <= maxCount ) 
		{
			timerCount = 0;
			enemyCount ++;
			Object newEnemy = Instantiate(enemyPrefab,player.transform.position + Random.onUnitSphere * range, new Quaternion(0,0,0,0));
		}
	}
}
