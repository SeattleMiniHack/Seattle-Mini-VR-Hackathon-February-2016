using UnityEngine;
using System.Collections;

public class BearChase : MonoBehaviour {

	public Vector3 target_position;
	private Transform transform;

	// Use this for initialization
	void Start () {
		transform = GetComponent<Transform>();
		target_position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float speed = 0.02f;
		//target_position = GameObject.Find ("Player").GetComponent<Transform> ().position;
		Vector3 diff = target_position - transform.position;
		transform.position += speed * diff.normalized;
	}

	public void SetTargetPosition(Vector3 _target_position) {
		target_position = _target_position;
		Debug.Log (target_position);
	}
}
