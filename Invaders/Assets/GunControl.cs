using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {

	public Camera myCam;
	public GameController myGameController;
	public EnemySpawner myEnemySpawner;
	public GameObject myBullet;

	void Start () 
	{
		myEnemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	void Update () 
	{
		RaycastHit hit;
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject bullet = (GameObject)Instantiate(myBullet,myCam.transform.position,myCam.transform.rotation);
			Vector3 point = myCam.transform.position + myCam.transform.forward;
			bullet.transform.LookAt(point);
			bullet.rigidbody.AddForce(bullet.transform.forward * 1000);

			if(Physics.Raycast(myCam.transform.position, myCam.transform.forward,out hit))
			{
				if(hit.collider.gameObject.tag == "enemy")
				{
					myEnemySpawner.enemyCount -=1;
					myEnemySpawner.enemies.Remove(hit.collider.gameObject);
					hit.collider.GetComponent<KillEnemy>().Kill();
					myGameController.score += 100;
				}
			}
		}
	}
}
