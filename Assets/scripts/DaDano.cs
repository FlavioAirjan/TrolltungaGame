using UnityEngine;
using System.Collections;
using System;

public class DaDano : MonoBehaviour {

    public float dist_dano;

    public int dano;
    public bool destroiAtacante;

    public int enemyLayer;
    public int playerLayer;

    private GameObject Player;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void enemyAttack()
    {
        
        if (gameObject.layer == enemyLayer)
        {
            Debug.Log(gameObject.name);
          if (gameObject.GetComponent<Enemy_0>().atacking == true)
        {
            if (Math.Abs(gameObject.transform.position.x - Player.transform.position.x) <= dist_dano)
            {
                
                Player.GetComponent<playerController>().PerdeVida(dano);

                    Vector2 v = Player.GetComponent<Rigidbody2D>().velocity;
                    v.x = Player.GetComponent<playerController>().lastHdirection * -2f;
                    v.y = 2f;
                    Player.GetComponent<Rigidbody2D>().velocity = v;

                }

            }
        }
    }
    

    void OnTriggerEnter2D(Collider2D colisor)
    {
        

        //Se a colisão for com o inimigo e o atacante não for o próprio inimigo.
        if (colisor.gameObject.layer == enemyLayer && gameObject.layer != enemyLayer)
        {
            int dir;
            //Tira vida do inimigo.
            var inimigo = colisor.gameObject.GetComponentInChildren<vidaObjeto>();

            inimigo.PerdeVida(dano);

            Vector2 position = colisor.gameObject.transform.position;
            if (colisor.gameObject.GetComponent<Enemy_0>().dir >= 0)
            {
                dir = 1;
            }
            else
            {
                dir = -1;
            }
            
            position.x += dir * -0.3f;

            


           
            colisor.gameObject.GetComponent<Rigidbody2D>().MovePosition(position);
            


        }

       


       
        /*
                //Se for tiro.
                if (gameObject.tag == "Tiro")
                {
                    //Se a colisao não for com o player.
                    if (colisor.gameObject.tag != "Player")
                    {
                        //Se destroiAtacante tiver habilitado.
                        if (destroiAtacante)
                        {
                            //destroi o atacante.
                            Destroy(gameObject);
                        }

                    }

                }
                //Se não for tiro.
                else
                {
                    //Se destroiAtacante tiver habilitado.
                    if (destroiAtacante)
                    {
                        //destroi o atacante.
                        Destroy(gameObject);
                    }
                }
         */
    }





}
