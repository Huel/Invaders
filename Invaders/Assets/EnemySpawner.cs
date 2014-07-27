using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public int maxCount; 	// max enemies spawned by spawner
	public float spawnRate; 	//spawns in sec
	public int range;		// positional range
	public GameObject enemyPrefab1;
	public GameObject enemyPrefab2;
	public GameObject enemyPrefab3;

	public GameObject player;
	public int enemyCount;
	public List<GameObject> enemies = new List<GameObject>();

	private float timerCount;
	private int enemyType;

	void Start () 
	{
		maxCount = 50;
		spawnRate = 2.0f;
		range = 750;
		timerCount = 0.0f;
		enemyType = 0;
	}
	
	void Update ()
	{
		timerCount += Time.deltaTime;
		spawnRate -= 0.01f * Time.deltaTime;

		float realSpawnRate = Mathf.Max (0.25f, spawnRate);
		Debug.Log ("spawnRate: " + spawnRate + ", realSpawnRate: " + realSpawnRate);

		if (timerCount > spawnRate && enemyCount < maxCount ) 
		{
			timerCount = 0;
			enemyCount ++;
			if(enemyType >= 3)
				enemyType = 0;

			enemyType ++;

			Vector3 startPosition = new Vector3(player.transform.position.x,player.transform.position.y, player.transform.position.z + range);
			Object enemy;

			switch(enemyType)
			{
			case 1:
				enemy = Instantiate(enemyPrefab1, startPosition + Random.onUnitSphere * range, new Quaternion(0,0,0,0));
				break;
			case 2:
				enemy = Instantiate(enemyPrefab2, startPosition + Random.onUnitSphere * range, new Quaternion(0,0,0,0));
				break;
			default:
			case 3:
				enemy = Instantiate(enemyPrefab3, startPosition + Random.onUnitSphere * range, new Quaternion(0,0,0,0));
				break;
			}
			enemies.Add((GameObject)enemy);
		}
	}
}
