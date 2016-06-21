using UnityEngine;
using System.Collections;
using System;

public class mobSpawn : MonoBehaviour {

    public float range;
    public Transform target;
    private float dirx;
    private float diry;
    private bool on;
    public string nameIA;
    public mobIA mob;




    // Use this for initialization
    void Start () {
        //GetComponent<Enemy_0>().stopmove();
        on = false;
   
        mob = gameObject.GetComponent(nameIA) as mobIA;
    }

    public string myIA()
    {
        return nameIA;
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
        {
            dirx = Math.Abs(target.position.x - transform.position.x);
            diry = Math.Abs(target.position.y - transform.position.y);

            if (dirx < range && diry <range/3)
            {
                on = true;
                mob.start();
                
            }
        }
    }

}
