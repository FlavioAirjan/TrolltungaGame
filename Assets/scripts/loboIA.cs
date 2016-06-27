using UnityEngine;
using System.Collections;

public class loboIA : MonoBehaviour, mobIA
{

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
    public AudioClip damageSound;
    public AudioClip startSound;
    public AudioClip deadSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool stop;
    private bool deadStop;
    private Vector2 direction;

    public void Start()
    {
        source = GetComponent<AudioSource>();
        GetComponent<CircleCollider2D>().enabled = false;
        //target = GameObject.Find("Player").transform;
        atacking = false;
        animator = enemy.GetComponent<Animator>();
        animator.enabled = false;
        stop = true;
        deadStop = false;
    }

    public void Update()
    {

        if (stop == false && deadStop == false)
        {
            if (target != null && atacking == false)
            {
                dir = target.position.x - transform.position.x;
                dirxy = Vector2.Distance(transform.position, target.position);
                if (dirxy > dist)
                {
                    animator.SetBool("walk", true);
                    
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
                else if(dirxy <= dist)
                {

                    StartCoroutine(Atack());
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
        playsound(damageSound);
    }

    private void playsound(AudioClip audio)
    {
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(audio, vol);
    }
    public IEnumerator Atack()
    {
        stop = true;
        direction.y = 1f;
        atacking = true;
        animator.SetBool("walk", false);
        animator.SetBool("atack", true);
        yield return new WaitForSeconds(0.8f);
        playsound(attack1Sound);
        
        bool dano=gameObject.GetComponent<DaDano>().enemyAttack();
       
            //adiciona velocidade para o pulo do lobo
            for (int i = 0; i < 27; i++)
            {
                if (transform.GetComponent<Rigidbody2D>() != null)
                {
                    transform.GetComponent<Rigidbody2D>().velocity = (direction * moveSpeed);
                    yield return new WaitForSeconds(0.04f);
                    direction.y -= 0.08f;
                    if (!dano)
                    {
                        dano = gameObject.GetComponent<DaDano>().enemyAttack();
                    }
                }
            }
        if (transform.GetComponent<Rigidbody2D>() != null)
        {
            direction.y = 0;
            animator.SetBool("atack", false);
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            //yield return new WaitForSeconds(0.5f);

            yield return new WaitForSeconds(1.0f);
        }
        atacking = false;
        stop = false;

    }

    public void damaged()
    {
        if (stop == false)
        {
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
        playsound(startSound);
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
        playsound(deadSound);
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
