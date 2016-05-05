using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{

    public Transform spritePlayer;
    private Animator animator;

    public float initialVelocity = 2;
    public float velocity;

    public float initialJumpForce = 150f;
    public float jumpForce;

    public float Hdirection = 0;

    public int maxJumps = 1;
    public int jumps = 0;

    public bool isOnFloor;


    // Use this for initialization
    void Start()
    {
        animator = spritePlayer.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Moviments();

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
            
            transform.Translate(Vector2.right * velocity * Time.deltaTime);
            spritePlayer.GetComponent<SpriteRenderer>().flipX = true;

        }

        if (Hdirection < 0)
        {
            transform.Translate(Vector2.left * velocity * Time.deltaTime);
            spritePlayer.GetComponent<SpriteRenderer>().flipX = false;

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



}
