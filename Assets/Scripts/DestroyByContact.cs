using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
	private PlayerController playerController;

	void Start ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		if (player != null) {
			playerController = player.GetComponent <PlayerController> ();
		}
		if (playerController == null) {
			Debug.Log ("Cannot find 'PlayerController' script");
		}
	}

	/*
	IEnumerator Wait (float seconds)
	{
		yield return new WaitForSeconds (seconds);
		playerController.GameOver ();
	}
	*/

	void OnCollisionEnter (Collision collision)
	{
		if (collision.gameObject.tag == "Player") {
			//Destroy (collision.gameObject);
			playerController.StopPlayerMovement ();
			//StartCoroutine (Wait (0.3f));
		}
	}
}
