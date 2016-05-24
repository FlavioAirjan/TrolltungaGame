using UnityEngine;
using System.Collections;

public class Enemy_0 : MonoBehaviour{
    public Transform target;
    public Transform enemy;

    private Animator animator;
    public int moveSpeed;
    public int rotationSpeed;

    void Start()
    {
        //target = GameObject.Find("Player").transform;
        animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {


        if (target != null)
        {
            float dir = target.position.x - transform.position.x;
            if (dir>0.5||dir<-0.5) {
                animator.SetBool("walk",true);
                Vector2 direction;
                direction.x = 0;
                direction.y = 0;
                if (dir < 0)
                {
                    direction.x = -1;
                    enemy.GetComponent<SpriteRenderer>().flipX = true;


                }

                if (dir > 0)
                {
                    direction.x = 1;
                    enemy.GetComponent<SpriteRenderer>().flipX = false;

                }
                //Move Towards Target

                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }else
            {
                animator.SetBool("walk", false);
            }
        }
        
        transform.GetComponent<Rigidbody2D>().velocity= Vector3.zero;
      
    }


}
