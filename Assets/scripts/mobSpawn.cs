using UnityEngine;
using System.Collections;

public class mobSpawn : MonoBehaviour {

    public float range;
    public Transform target;
    private float dir;
    private bool on;



    // Use this for initialization
    void Start () {
        //GetComponent<Enemy_0>().stopmove();
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
        {
            dir = target.position.x - transform.position.x;
            if (dir < 0)
            {
                dir = dir * -1;
            }
            if (dir < range)
            {
                GetComponent<Enemy_0>().start();
                on = true;
            }
        }
    }

}
