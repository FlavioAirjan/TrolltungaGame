using UnityEngine;
using System.Collections;

public class magpie_move : MonoBehaviour {
	public float speed = 0.02f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}
}
