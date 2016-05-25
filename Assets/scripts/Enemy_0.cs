using UnityEngine;
using System.Collections;

public class Enemy_0 : MonoBehaviour{
    public Transform target;
    public Transform enemy;

    private Animator animator;
    public int moveSpeed;
    public int rotationSpeed;
    private bool atacking;

    void Start()
    {
        //target = GameObject.Find("Player").transform;
        atacking = false;
        animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {


        if (target != null && atacking == false)
        {
            float dir = target.position.x - transform.position.x;
            if (dir > 0.5 || dir < -0.5)
            {
                animator.SetBool("walk", true);
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
            }
            else
            {

                StartCoroutine(Atack());
            }
        }
        else
        {

            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
      
    }

    IEnumerator Atack()
    {
            atacking = true;
            animator.SetBool("walk", false);
            animator.SetBool("atack", true);
            yield return new WaitForSeconds(1);
            animator.SetBool("atack", false);
            yield return new WaitForSeconds(1);
            atacking = false;
    }


}
