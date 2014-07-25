using UnityEngine;
using System.Collections;

public class GunControl : MonoBehaviour {

	public Camera myCam;
	public GameController myGameController;

	void Start () 
	{
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
					Debug.Log("BOOM");
					Destroy(hit.collider.gameObject);
					myGameController.score += 100;
				}
			}
		}
	}
}
