using UnityEngine;
using System.Collections;

public class GetChasedIfTooFarFromNode : MonoBehaviour {

	public float chase_after_distance = 30;

	GameObject bear;

	// Use this for initialization
	void Start () {
		bear = GameObject.Find ("Bear");
	}
	
	// Update is called once per frame
	void Update () {
		float distance = -1.0f;
		Vector3 position = GetComponent<Transform> ().position;
		foreach (AudioNode node in GameObject.FindObjectsOfType<AudioNode>()) {
			Vector3 node_position = node.GetComponent<Transform> ().position;
			Vector3 diff = position - node_position;
			float _distance = diff.magnitude;
			if (distance < 0.0f || _distance < distance)
				distance = _distance;
		}	

		if (distance > chase_after_distance) {
			bear.GetComponent<BearChase> ().SetTargetPosition (position);
		}
	}
}
