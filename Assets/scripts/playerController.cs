using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{

    public int activedAttack;

    public GameObject Tiro1; // Tiro1
    public GameObject Tiro2; //Tiro2
    public GameObject Tiro3; //Tiro3
   
    

    public GameObject weaponRight;
    public GameObject weaponLeft;

    public int maxVida;
    private int vidaAtual;
    private GameObject painelVida;

    public int maxMana;
    private int manaAtual;
    private GameObject painelMana;


    public Transform spritePlayer;
    private Animator animator;
    private bool stopMove;

    public float initialVelocity = 2;
    public float velocity;

    public float initialJumpForce = 150f;
    public float jumpForce;

    public float Hdirection = 0;
    public float lastHdirection = 0;

    public int maxJumps;
    public int jumps = 0;

    public bool isOnFloor;
    public AudioClip attack1Sound;
    public AudioClip attack2Sound;
    private AudioSource source;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    public bool pause;


    // Use this for initialization
    void Start()
    {
        pause = false;
        source = GetComponent<AudioSource>();
        vidaAtual = maxVida;
        manaAtual = maxMana;

        lastHdirection = 1f;
        maxJumps = 2;
        animator = spritePlayer.GetComponent<Animator>();
        painelVida = GameObject.Find("Canvas/PainelVida");
        painelMana = GameObject.Find("Canvas/PainelMana");
        painelVida.GetComponentInChildren<Text>().text = "  " + "HP    " + vidaAtual.ToString() + "  /  " + maxVida.ToString();
        painelMana.GetComponentInChildren<Text>().text = "  " + "Mana  " + manaAtual.ToString() + "  /  " + maxMana.ToString();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (pause==false) {
            chooseSpecialAttack();

            if (!stopMove)
            {
                attack();

                if (!stopMove)
                {
                    Moviments();
                }
            }
        }
        

    }

    void chooseSpecialAttack()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activedAttack = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            activedAttack = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            activedAttack = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            activedAttack = 0;
        }

    }

    IEnumerator Atack(int attack)
    {
        float vol = Random.Range(volLowRange, volHighRange);
       
        animator.SetInteger("Attack", attack);

        //Seleciona o som do ataque normal
        yield return new WaitForSeconds((float)0.3);
        if (attack == 1)
        {
            source.PlayOneShot(attack1Sound, vol);
        }
        else if (attack == 2)
        {
            source.PlayOneShot(attack2Sound, vol);
        }
        

       yield return new WaitForSeconds((float)0.4);

        if (attack == 1)
        {
            if (lastHdirection == 1)
            {
                weaponRight.SetActive(true);
            }
            else
            {
                weaponLeft.SetActive(true);
            }
            
        }
        else if (attack == 2)
        {
            weaponRight.SetActive(true);
            weaponLeft.SetActive(true);
           
        }
        else if (attack == 3)
        {
            int currentAttack;

            //Se não tiver mana, o ataque vai cair no caso default, ou seja, não disparará magia.

            if (manaAtual <= 0 || !gameObject.GetComponent<MyItems>().runeAvailable(activedAttack))
            {
                //criei a variável currentAttack, porque assim a activedAttack nunca vai setar para outro valor, 
                //a não ser o que o player setar.
                currentAttack = -1;
                
            }
            else
            {
                currentAttack = activedAttack;
            }
            
            //Inicia o golpe especial e o som do golpe
            switch (currentAttack) {
                
                case 1:
                    
                    Instantiate(Tiro1, transform.position, Tiro1.transform.rotation);
                    gameObject.GetComponent<MyItems>().useRune(currentAttack);
                    PerdeMana(10);
                    break;
                case 2:
                    
                    Instantiate(Tiro2, transform.position, Tiro1.transform.rotation);
                    gameObject.GetComponent<MyItems>().useRune(currentAttack);
                    PerdeMana(10);
                    break;
                case 3:
                  
                    Instantiate(Tiro3, transform.position, Tiro1.transform.rotation);
                    gameObject.GetComponent<MyItems>().useRune(currentAttack);
                    PerdeMana(10);
                    break;
                default:
                    if (lastHdirection == 1)
                    {
                        weaponRight.SetActive(true);
                    }
                    else
                    {
                        weaponLeft.SetActive(true);
                    }
                    break;

            }
        
        }
        
        animator.SetInteger("Attack", 0);
        yield return new WaitForSeconds((float)0.2);
        stopMove = false;


    }


    void attack()
    {
        bool atack1 = Input.GetButtonDown("Fire1");
        bool atack2 = Input.GetButtonDown("Fire2");
        bool atack3 = Input.GetButtonDown("Fire3");

        if (atack1||atack2|| atack3)
        {
            stopMove = true;
            animator.SetFloat("Hdirection",0);
            if (atack1)
            {
                StartCoroutine(Atack(1));
            }
            else if(atack2)
            {
                StartCoroutine(Atack(2));
            }
            else
            {
                StartCoroutine(Atack(3));
            }

            

        }
        else
        {
            weaponRight.SetActive(false);
            weaponLeft.SetActive(false);
        }

    }

    void Moviments()
    {

        velocity = initialVelocity;
        jumpForce = initialJumpForce;

        Hdirection = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Hdirection", Mathf.Abs(Hdirection));


        if (isOnFloor == true)
        {
            jumps = maxJumps;
        }


        if (Hdirection > 0)
        {
            lastHdirection = Hdirection;
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
            spritePlayer.GetComponent<SpriteRenderer>().flipX = false;

        }

        if (Hdirection < 0)
        {
            lastHdirection = Hdirection;
            transform.Translate(Vector2.left * velocity * Time.deltaTime);
            spritePlayer.GetComponent<SpriteRenderer>().flipX = true;

        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps > 0)
        {

            //Decrementa o numero de pulos.
            jumps--;

            //Seta a velocidade y para 0, assim, o personagem não sobe muito caso aperte o botão de pular em intervalos de tempo pequeno.
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

            //Será aplicada uma força para cima(transform.up) contra a gravidade.
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);


        }

    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        if (collisor.gameObject.layer == enemyLayer)
        {
            Vector2 v = gameObject.GetComponent<Rigidbody2D>().velocity;
            if (collisor.gameObject.transform.position.x - transform.position.x > 0)
            {
                
                v.x = -2f;
            }
            else
            {
                v.x = 2f;
            }

            v.y = 2f;
            gameObject.GetComponent<Rigidbody2D>().velocity = v;
            

        }
    }

    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        

        if (vidaAtual <= 0)
        {
            vidaAtual = 0;

            //DestroyObject(gameObject);
            Debug.Log("morreu");
        }

        painelVida.GetComponentInChildren<Text>().text = "  " + "HP    " + vidaAtual.ToString() + "  /  " + maxVida.ToString();



    }

    public void ganhaVida(int valor)
    {

        vidaAtual += valor;



        if (vidaAtual >= maxVida)
        {
            vidaAtual = maxVida;


        }

        painelVida.GetComponentInChildren<Text>().text = "  " + "HP    " + vidaAtual.ToString() + "  /  " + maxVida.ToString();


    }

    public void ganhaMana(int valor)
    {

        manaAtual += valor;



        if (manaAtual >= maxMana)
        {
            manaAtual = maxMana;


        }

        painelMana.GetComponentInChildren<Text>().text = "  " + "Mana  " + manaAtual.ToString() + "  /  " + maxMana.ToString();

    }

    public void PerdeMana(int dano)
    {
        manaAtual -= dano;



        if (manaAtual <= 0)
        {
            manaAtual = 0;

        }

        painelMana.GetComponentInChildren<Text>().text = "  " + "Mana  " + manaAtual.ToString() + "  /  " + maxMana.ToString();



    }


}
