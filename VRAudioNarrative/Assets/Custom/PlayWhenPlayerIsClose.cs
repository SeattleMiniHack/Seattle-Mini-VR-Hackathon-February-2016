using UnityEngine;
using System.Collections;

public class PlayWhenPlayerIsClose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		CharacterController user = other.GetComponent<CharacterController>();
		if (user == null) return;
		AudioSource audio = GetComponent<AudioSource> ();
		if (!audio.isPlaying)
			audio.Play ();
	}
}
