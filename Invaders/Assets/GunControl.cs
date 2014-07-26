using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {

	public Camera myCam;
	public GameController myGameController;
	public EnemySpawner myEnemySpawner;

	void Start () 
	{
		myEnemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	void Update () 
	{
		RaycastHit hit;
		if(Input.GetButtonDown("Fire1"))
		{
			if(Physics.Raycast(myCam.transform.position, myCam.transform.forward,out hit))
			{
				if(hit.collider.gameObject.tag == "enemy")
				{
					myEnemySpawner.enemyCount -=1;
					myEnemySpawner.enemies.Remove(hit.collider.gameObject);
					Destroy(hit.collider.gameObject);
					myGameController.score += 100;
				}
			}
		}
	}
}
