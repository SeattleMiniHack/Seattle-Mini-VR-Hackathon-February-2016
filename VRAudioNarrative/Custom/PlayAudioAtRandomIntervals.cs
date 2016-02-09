using UnityEngine;
using System.Collections;

public class PlayAudioAtRandomIntervals : MonoBehaviour {

	public float max_time_delay = 10.0f;
	public float min_time_delay = 3.0f;
	float time = 0.0f;

	public void StartCountdown() {
		time = min_time_delay + (max_time_delay - min_time_delay) * Random.value;
	}

	public void PlaySound() {
		AudioSource audio = GetComponent<AudioSource> ();
		if (!audio.isPlaying)
			audio.Play ();
	}

	// Use this for initialization
	void Start () {
		StartCountdown ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (time);
		if (time < 0.0f) {
			StartCountdown ();
			PlaySound ();
		} else {
			time -= Time.deltaTime;
		}
	}
}
