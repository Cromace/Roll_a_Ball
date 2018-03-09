using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Controller : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text loseText;
	public Text changeLevelText;
	public Text livesText;
	public float myPosition;
	public Vector3 resetPos;
	public float timeToDisplay = 3;

	private Rigidbody rb;
	public static int count;
	private int lives;

	void Start (){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		lives = 3;
		SetCountText ();
		winText.text = "";
		loseText.text = "";
		changeLevelText.text = "";
		SetLivesText ();
		resetPos = transform.position;
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

		myPosition = transform.position.y;
		if (myPosition <= -2 && count < 10) {
			lives--;
			SetLivesText();
			if (lives <= 0) {
				loseText.text = "You lost !";
			}
			transform.position = resetPos;
		} else if (myPosition <= -2 && count >= 10) {
			lives--;
			SetLivesText();
			if (lives <= 0) {
				loseText.text = "You lost !";
			}
			transform.position = new Vector3 (68.0f, 2.0f, 3.0f);
		}
	}		
		


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
			if (count == 9) {
				changeLevelText.text = "Go to the teleporter !";
				Destroy (changeLevelText, timeToDisplay);
			} else if (count >= 15) {
				winText.text = "You Win !";
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if(other.gameObject.CompareTag("Teleporter") && count == 9){
			transform.position = new Vector3 (68.0f, 2.0f, 3.0f);
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
	}

	void SetLivesText(){
		livesText.text = "Lives: " + lives.ToString ();
	}

}