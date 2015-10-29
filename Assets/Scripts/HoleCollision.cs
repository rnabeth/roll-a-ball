using UnityEngine;
using System.Collections;

public class HoleCollision : MonoBehaviour
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

	void OnTriggerEnter (Collider other)
	{
		GetComponent<AudioSource> ().Play ();
		if (other.tag == "Player") {
			var audio = GetComponent<AudioSource> ();
			audio.Play ();
			playerController.GameOver ();
		}
	}
}
