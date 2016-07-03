using UnityEngine;
using System.Collections;

public class bloodFloor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }



        // Use this for initialization
        void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
