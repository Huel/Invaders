using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public int maxCount; 	// max enemies spawned by spawner
	public int spawnRate; 	//spawns in sec
	public int range;		// positional range
	public GameObject enemyPrefab;
	public GameObject player;
	public int enemyCount;
	public List<GameObject> enemies = new List<GameObject>();

	private float timerCount;

	void Start () 
	{
		maxCount = 10;
		spawnRate = 5;
		range = 500;
		timerCount = 0.0f;
	}
	
	void Update ()
	{
		timerCount += Time.deltaTime;
		if (timerCount > spawnRate && enemyCount < maxCount ) 
		{
			timerCount = 0;
			enemyCount ++;
			Vector3 startPosition = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z + range);
			Object enemy = Instantiate(enemyPrefab, startPosition + Random.onUnitSphere * range, new Quaternion(0,0,0,0));
			enemies.Add((GameObject)enemy);
		}
	}
}
