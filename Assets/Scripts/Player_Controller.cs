using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public float myPosition;
	public Vector3 resetPos;

	private Rigidbody rb;
	private int count;

	void Start (){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
		resetPos = transform.position;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		myPosition = transform.position.y;
		if (myPosition <= -2) {
			transform.position = resetPos ;
		}
	}		
		


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}

		if (other.gameObject.CompareTag("SpeedSouth")){
			rb.AddForce(Vector3.back * speed);
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 9) {
			winText.text = "You Win!";
		}
	}
}