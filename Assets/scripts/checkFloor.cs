using UnityEngine;
using System.Collections;

public class checkFloor : MonoBehaviour {


    private bool floor;



    void OnTriggerStay2D(Collider2D target)
    {
        if (target.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            gameObject.GetComponentInParent<playerController>().isOnFloor = true;
        }

    }

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
              //  StartCoroutine(isFloor());
        }

    }

    IEnumerator isFloor()
    {
        floor=false;
        for (int i=0;i<100 && !floor ; i++) {
            floor = gameObject.GetComponentInParent<playerController>().isOnFloor;
            yield return new WaitForSeconds(0.01f);
        }
        if (!floor) {
            floor = true;
            gameObject.GetComponentInParent<playerController>().isOnFloor = true;
        }
    }

    // Use this for initialization
    void Start () {

        floor = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
