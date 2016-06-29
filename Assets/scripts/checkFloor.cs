using UnityEngine;
using System.Collections;

public class checkFloor : MonoBehaviour {




    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Floor"))
        { 
            gameObject.GetComponentInParent<playerController>().isOnFloor = true;
        }

        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (target.gameObject.layer == enemyLayer)
        {

            Vector2 v = gameObject.GetComponentInParent<Rigidbody2D>().velocity;
            v.x = gameObject.GetComponentInParent<playerController>().lastHdirection * -2f;
            v.y = 1f;
            gameObject.GetComponentInParent<Rigidbody2D>().velocity = v;



        }

    }
    
    void OnTriggerExit2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Floor"))
        { 
            gameObject.GetComponentInParent<playerController>().isOnFloor = false;
        }

    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
