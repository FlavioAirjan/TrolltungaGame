using UnityEngine;
using System.Collections;

public class TrollIA : MonoBehaviour,mobIA {

    public Transform target;
    public Transform enemy;
    public float dist;

    private Animator animator;
    public int moveSpeed;
    public int rotationSpeed;
    public bool atacking;
    public float dir;
    private float dirxy;
    public GameObject Tiro1;

    public AudioClip attack1Sound;
    public AudioClip damageSound;
    public AudioClip startSound;
    public AudioClip deadSound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private bool stop;
    private bool deadStop;

    public void Start()
    {
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

        if (stop == false && deadStop == false)
        {
            if (target != null && atacking == false)
            { 
                    dir = target.position.x - transform.position.x;
                    dirxy = Vector2.Distance(transform.position, target.position);
                    if (dirxy > dist)
                    {
                    int atack = Random.Range(0,1500);

                    if (atack < 10)
                    {
                        if (dir < 0)
                        {
                            enemy.GetComponent<SpriteRenderer>().flipX = true;
                        }

                        if (dir > 0)
                        {
                            enemy.GetComponent<SpriteRenderer>().flipX = false;

                        }
                            StartCoroutine(Atack(3));
                    }
                    else
                    {
                        animator.SetBool("Walk", true);
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


                    }
                    else
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
                            StartCoroutine(Atack(0));
                        }
                    }
                
            }
            else
            {

                transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }

    }





    private void playsound(AudioClip audio)
    {
        if (source.isActiveAndEnabled)
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(audio, vol);
        }
    }

    public bool isAtacking()
    {
        return (atacking);
    }

    public void hitsound()
    {

        //playsound(attack1Sound);
    }
    public IEnumerator Atack()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator Atack(int attack)
    {
        int atack = Random.Range(0, 20);
        if (attack==3) {
            atack = 3;
        } else {
            if (atack < 10)
            {
                atack = 1;
            }
            else if (atack < 20)
            {
                atack = 2;
            }
            
        }
        if (animator.isActiveAndEnabled)
        {
            stop = true;
            atacking = true;
            animator.SetBool("Walk", false);
            animator.SetInteger("Attack", atack);
            playsound(attack1Sound);
            yield return new WaitForSeconds(1f);
            if (atack != 3)
            {
                animator.SetInteger("Attack", 0);
                gameObject.GetComponent<DaDano>().enemyAttack();
                yield return new WaitForSeconds(1.0f);
            }
            else
            {
                Instantiate(Tiro1, transform.position, Tiro1.transform.rotation);
                yield return new WaitForSeconds(1f);
                animator.SetBool("charge", true);
                gameObject.GetComponent<DaDano>().enemyAttack();

                yield return new WaitForSeconds(1f);
                animator.SetInteger("Attack", 0);
                animator.SetBool("charge", false);
                
            }
            stop = false;
            atacking = false;
        }

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
        playsound(damageSound);
        animator.SetBool("Damaged", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("Damaged", false);
        stop = false;

    }

    public void stopmove()
    {
        stop = true;
        animator.SetBool("Walk", false);
        animator.SetInteger("Attack", 0);
        animator.SetBool("Damaged", false);
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
        playsound(deadSound);
        deadStop = true;
        // Debug.Log("teste dead");
        GetComponent<BoxCollider2D>().enabled = false;
        animator.SetBool("Dead", true);
        Destroy(GetComponent<Rigidbody2D>());
    }

    public void live()
    {
        deadStop = false;
        animator.SetBool("Dead", false);
        GetComponent<BoxCollider2D>().enabled = true;
        gameObject.AddComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        start();

    }

    public float dirValue()
    {
        return dir;
    }
}
