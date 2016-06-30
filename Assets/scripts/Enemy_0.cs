using UnityEngine;
using System.Collections;

public class Enemy_0 : MonoBehaviour, mobIA {

    public Transform target;
    public Transform enemy;
    public float dist;

    private Animator animator;
    public int moveSpeed;
    public int rotationSpeed;
    public bool atacking;
    public float dir;
    private float dirxy;

    public AudioClip attack1Sound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool stop;
    private bool deadStop;

    public void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        source = GetComponent<AudioSource>();
        //target = GameObject.Find("Player").transform;
        atacking = false;
        animator = enemy.GetComponent<Animator>();
        animator.enabled = false;
        stop = true;
        deadStop = false;
       
    }

    public void Update()
    {

        if (stop == false && deadStop==false) {
        if (target != null && atacking == false )
        {
            dir = target.position.x - transform.position.x;

                dirxy = Vector2.Distance(transform.position, target.position);
                if (dirxy > dist)
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
            else if (dirxy <= dist)
                {
                    if (dir < 0)
                    {
                        enemy.GetComponent<SpriteRenderer>().flipX = true;
                    }

                    if (dir > 0)
                    {
                        enemy.GetComponent<SpriteRenderer>().flipX = false;

                    }
                    if (Vector2.Distance(transform.position, target.position) < dist + 0.2)
                    {
                        StartCoroutine(Atack());
                    }
                }
        }
        else
        {

            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        }

    }

    public void hitsound()
    {
        float vol = Random.Range(volLowRange, volHighRange);
        if (source.isActiveAndEnabled)
        {
            source.PlayOneShot(attack1Sound, vol);
        }
    }

    public IEnumerator Atack()
    {
        
        atacking = true;
            animator.SetBool("walk", false);
            animator.SetBool("atack", true);
        yield return new WaitForSeconds(0.7f);
        yield return new WaitForSeconds(0.3f);
            
            animator.SetBool("atack", false);
        //yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<DaDano>().enemyAttack();
            yield return new WaitForSeconds(1.0f);
            
            atacking = false;
       

    }

    public void damaged()
    {
        if (stop==false) {
            StartCoroutine(damagedAmine());
        }
    }


    public IEnumerator damagedAmine()

    {
        stopmove();
        animator.SetBool("damaged", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("damaged", false);
        stop = false;

    }

    public void stopmove()
    {
        stop = true;
        animator.SetBool("walk", false);
        animator.SetBool("atack", false);
        animator.SetBool("damaged", false);
        //transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }

    public void start()
    {
        stop = false;
        animator.enabled = true;
    }

    public void dead()
    {
        stopmove();
        deadStop = true;
        // Debug.Log("teste dead");
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<CircleCollider2D>().isTrigger = false;
        GetComponent<BoxCollider2D>().enabled = false;
        
        animator.SetBool("dead", true);
        Destroy(GetComponent<Rigidbody2D>());


    }

    public void live()
    {
        deadStop = false;
        animator.SetBool("dead", false);
        start();
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<BoxCollider2D>().enabled = true;
    }

    public bool isAtacking()
    {
        return (atacking);
    }


    public float dirValue()
    {
        return dir;
    }


}
