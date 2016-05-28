using UnityEngine;
using System.Collections;

public class Enemy_0 : MonoBehaviour{
    public Transform target;
    public Transform enemy;
    public float dist;

    private Animator animator;
    public int moveSpeed;
    public int rotationSpeed;
    public bool atacking;
    public float dir;

    public AudioClip attack1Sound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    void Start()
    {
        source = GetComponent<AudioSource>();
        //target = GameObject.Find("Player").transform;
        atacking = false;
        animator = enemy.GetComponent<Animator>();
    }

    void Update()
    {


        if (target != null && atacking == false)
        {
            dir = target.position.x - transform.position.x;
            if (dir > dist || dir < -dist)
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
        float vol = Random.Range(volLowRange, volHighRange);
        atacking = true;
            animator.SetBool("walk", false);
            animator.SetBool("atack", true);
        yield return new WaitForSeconds(0.7f);
        source.PlayOneShot(attack1Sound, vol);
        yield return new WaitForSeconds(0.3f);
            
            animator.SetBool("atack", false);
            //yield return new WaitForSeconds(0.5f);
            gameObject.GetComponent<DaDano>().enemyAttack();
            yield return new WaitForSeconds(1.0f);
            
            atacking = false;
       

    }


}
