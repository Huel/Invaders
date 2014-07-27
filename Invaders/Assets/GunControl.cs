using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {

	public Camera myCam;
	public GameController myGameController;
	public EnemySpawner myEnemySpawner;
	public GameObject myBullet;
	public GameObject player;

	void Start () 
	{
		myEnemySpawner = GameObject.FindGameObjectWithTag ("EnemySpawner").GetComponent<EnemySpawner>();
	}
	
	void Update () 
	{
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject forwardDir = GameObject.FindGameObjectWithTag("ForwardDir");
			Vector3 shootPosLeft = myCam.transform.position+ myCam.transform.right * -1;
			Vector3 shootPosRight = myCam.transform.position+ myCam.transform.right * 1;
			GameObject bulletLeft = (GameObject)Instantiate(myBullet, shootPosLeft,myCam.transform.rotation);
			GameObject bulletRight = (GameObject)Instantiate(myBullet, shootPosRight,myCam.transform.rotation);
			Vector3 point = myCam.transform.position + myCam.transform.forward * 1000;
			bulletRight.transform.LookAt(point);
			bulletRight.rigidbody.AddForce(bulletRight.transform.forward * 15000);
			bulletLeft.transform.LookAt(point);
			bulletLeft.rigidbody.AddForce(bulletRight.transform.forward * 15000);

			player.audio.Play();
			
			//RaycastHit hit;
			/*if(Physics.Raycast(myCam.transform.position, myCam.transform.forward,out hit))
			{
				if(hit.collider.gameObject.tag == "enemy")
				{
					myEnemySpawner.enemyCount -=1;
					myEnemySpawner.enemies.Remove(hit.collider.gameObject);
					hit.collider.GetComponent<KillEnemy>().Kill();
					myGameController.score += 100;
				}
			}*/
		}
	}
}
