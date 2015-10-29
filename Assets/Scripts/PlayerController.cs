using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;
	public Text countText;
	public Text centerText;

	public AudioSource pickUpCollectedSound;
	public AudioSource gameOverSound;
	public AudioSource youWinSound;

	private int count;
	private bool gameOver;
	private bool blockPlayerControl;

	void Start ()
	{
		count = 0;
		SetCountText ();
		centerText.text = "";
		gameOver = false;
		blockPlayerControl = false;
	}

	void Update ()
	{
		if (gameOver) {
			if (Input.GetKeyDown (KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

	// Called just before performing any physics calculations (using forces)
	void FixedUpdate ()
	{
		if (!blockPlayerControl) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");

			Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

			// When you multiply with Time.deltaTime you essentially express: I want to move this object 10 meters per second instead of 10 meters per frame.
			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
			pickUpCollectedSound.Play ();
		}
	}

	public void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) {
			centerText.text = "YOU WIN!\nPress 'R' to Restart";
			youWinSound.Play ();
			gameOver = true;
			blockPlayerControl = true;
			StopPlayerMovement ();
		}
	}

	public void GameOver ()
	{
		gameOver = true;
		StartCoroutine (PlayGameOverSound ());
	}

	public void StopPlayerMovement ()
	{
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezeRotation;
		gameObject.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.FreezePosition;
	}

	IEnumerator PlayGameOverSound ()
	{
		yield return new WaitForSeconds (5.7f);
		gameOverSound.Play ();
		centerText.text = "Game Over!\nPress 'R' to Restart";
	}
}
