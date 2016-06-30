using UnityEngine;
using System.Collections;

public class boarIA : MonoBehaviour,mobIA {

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
    private bool stopRun;
  

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
        stopRun = false;
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
                else if (dirxy <= dist)
                {
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
        if (source.isActiveAndEnabled)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(audio, vol);
        }
    }
    public IEnumerator Atack()
    {

        atacking = true;
        animator.SetBool("walk", true);

        yield return new WaitForSeconds(0.8f);
       

        bool dano = gameObject.GetComponent<DaDano>().enemyAttack();
        dirxy = Vector2.Distance(transform.position, target.position);
       
        //adiciona velocidade para o pulo do lobo
        for (int i = 0;i<100 && !dano && dirxy<dist*1.5 && !stopRun; i++)
        {
            dirxy = Vector2.Distance(transform.position, target.position);
            if (transform.GetComponent<Rigidbody2D>() != null)
            {
                transform.Translate(direction * moveSpeed * Time.deltaTime*3);
                //transform.GetComponent<Rigidbody2D>().velocity += (direction * moveSpeed/2);
                yield return new WaitForSeconds(0.0001f);
                if (!dano)
                {
                    dano = gameObject.GetComponent<DaDano>().enemyAttack();
                }
                if (dano)
                {
                    playsound(attack1Sound);
                    if (animator.isActiveAndEnabled)
                        animator.SetBool("walk", false);
                    
                }
                
            }
        }
        if (transform.GetComponent<Rigidbody2D>()!=null) {
            transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        if (transform.GetComponent<Rigidbody2D>() != null && dirxy < dist * 1.5 && !stopRun && animator.isActiveAndEnabled)
        {
            animator.SetBool("walk", false);
            animator.SetBool("atack", true);
            yield return new WaitForSeconds(1.5f);
            animator.SetBool("atack", false);
            yield return new WaitForSeconds(1.5f);
            //yield return new WaitForSeconds(0.5f);


        }

        if (animator.isActiveAndEnabled)
            animator.SetBool("walk", false);
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
        playsound(attack1Sound);
        animator.SetBool("damaged", true);
        yield return new WaitForSeconds(1.5f);
        animator.SetBool("damaged", false);
        stop = false;
        stopRun = false;

    }

    public void stopmove()
    {
        stopRun = true;
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
