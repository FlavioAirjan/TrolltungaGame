using UnityEngine;
using System.Collections;

public class npcIA : MonoBehaviour
{

    public Canvas PauseMenu;
    public Canvas ControlMenu;
    public Canvas InventoryMenu;

    public bool interception = false;
    bool Walk = false;

    public float durationSpeechBubble = 2.0f;
    public float durationWalk = 4.0f;
    public float durationIdle = 3.0f;
    public int dir = 1;
    public float velocity = 1.5f;

    public float timeWalking;
    public float timeIdling;
    public float timeSpeechBubble;

    private Animator animator;
    public Transform spriteNPC;

    private int playerLayer;

    public GameObject speechBubble;

    // Use this for initialization
    void Start()
    {

        timeWalking = durationWalk;
        timeIdling = durationIdle;
        timeSpeechBubble = durationSpeechBubble;

        animator = spriteNPC.GetComponent<Animator>();

        animator.SetBool("Walk", Walk);

        playerLayer = LayerMask.NameToLayer("Player");




    }

    // Update is called once per frame
    void Update()
    {

        move();
        callMarketPanel();


    }


    public void move()
    {
        if (!interception)
        {
            timeSpeechBubble -= Time.deltaTime;
            if (timeSpeechBubble <= 0)
            {
                speechBubble.GetComponent<SpriteRenderer>().enabled = !speechBubble.GetComponent<SpriteRenderer>().enabled;
                timeSpeechBubble = durationSpeechBubble;
            }

            animator.SetBool("Walk", Walk);
            if (Walk)
            {
                timeWalking -= Time.deltaTime;
                transform.Translate(dir * Vector2.right * velocity * Time.deltaTime);

                if (timeWalking <= 0)
                {
                    timeWalking = durationWalk;
                    Walk = !Walk;
                }
            }
            else
            {

                timeIdling -= Time.deltaTime;
                if (timeIdling <= 0)
                {

                    timeIdling = durationIdle;
                    dir *= -1;
                    spriteNPC.GetComponent<SpriteRenderer>().flipX = !spriteNPC.GetComponent<SpriteRenderer>().flipX;
                    Walk = !Walk;
                }



            }

        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }


    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer == playerLayer)
        {
            interception = true;

        }

    }

    void OnTriggerExit2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer == playerLayer)
        {
            interception = false;

        }
    }

    void callMarketPanel()
    {

        if (interception == true)
        {
            if (Input.GetKeyDown(KeyCode.Return) && PauseMenu.enabled == false)
            {
                if (ControlMenu.enabled)
                {
                    ControlMenu.enabled = !ControlMenu.enabled;
                }

                if (InventoryMenu.enabled)
                {
                    InventoryMenu.enabled = !InventoryMenu.enabled;
                }


                Debug.Log("Chamar o inventário de venda!");
                

            }
        }

    }


}
