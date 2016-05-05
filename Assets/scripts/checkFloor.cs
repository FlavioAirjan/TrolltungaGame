using UnityEngine;
using System.Collections;

public class checkFloor : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D target)
    {
        gameObject.GetComponentInParent<playerController>().isOnFloor = true;
        


    }

    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            gameObject.GetComponentInParent<playerController>().isOnFloor = true;
        }
        
    }

    void OnTriggerExit2D(Collider2D target)
    {

        gameObject.GetComponentInParent<playerController>().isOnFloor = false;


    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
