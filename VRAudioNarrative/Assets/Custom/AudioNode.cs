using UnityEngine;
using System.Collections;
using System.Timers;


public class AudioNode : MonoBehaviour
{
	public AudioNode parent_node = null;
	Light light = null;

	float target_intensity;
	float intensity;

	// Use this for initialization
	void Start()
	{
		light = GetComponent<Light>();
		if (parent_node != null) {
			target_intensity = 0.0f;
		} else {
			target_intensity = 4.0f;
		}
		intensity = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		float speed = 0.1f;
		if (target_intensity < light.intensity)
			speed = 0.001f;
		intensity += (target_intensity - light.intensity) * speed;
		light.intensity = intensity;

	}

	void OnTriggerEnter(Collider other)
	{
		if (intensity <= 0.0f)
			return;

		CharacterController user = other.GetComponent<CharacterController>();
		if (user == null) return;
		foreach (AudioNode node in GameObject.FindObjectsOfType<AudioNode>())
		{
			if (node.parent_node == this)
			{
				node.Activate();
			}
		}

		target_intensity = 0.0f;
		Transform transform = GetComponent<Transform> ();
		GameObject bear = GameObject.Find ("Bear");
		bear.GetComponent<BearChase>().SetTargetPosition (transform.position);
	}

	public void Activate()
	{
		target_intensity = 4.0f;
	}
}
