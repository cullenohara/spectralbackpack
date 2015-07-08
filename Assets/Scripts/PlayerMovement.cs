using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rbody;

	void Start ()
	{
		rbody = GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if(Input.GetKey(KeyCode.W))
		{
			rbody.AddForce(Vector3.forward * 20);
		}
		if(Input.GetKey(KeyCode.S))
		{
			rbody.AddForce(Vector3.forward * -20);
		}
		if(Input.GetKey(KeyCode.A))
		{
			rbody.AddForce(Vector3.left * 20);
		}
		if(Input.GetKey(KeyCode.D))
		{
			rbody.AddForce(Vector3.right * 20);
		}
	}
}
