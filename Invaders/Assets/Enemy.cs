using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public GameController myGameController;

	void Start () {
	}
	
	void Update () 
	{
		this.transform.Rotate (new Vector3(1.0f,1.0f,1.0f));
		this.transform.position = Vector3.Lerp (this.transform.position, player.transform.position, Time.deltaTime/5);
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Player")
		{
			myGameController.health -= 1;	
			Destroy(this.gameObject);
			Debug.Log("OUCH!");
		}
	}
}
