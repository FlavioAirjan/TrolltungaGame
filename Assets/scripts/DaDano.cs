using UnityEngine;
using System.Collections;
using System;

public class DaDano : MonoBehaviour {

    public float dist_dano;

    public int dano;
    public bool destroiAtacante;

    private int enemyLayer;
    private int playerLayer;
    private int tiroLayer;
    private int weaponLayer;

    private GameObject Player;


    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
        tiroLayer = LayerMask.NameToLayer("Tiro");
        weaponLayer = LayerMask.NameToLayer("Weapon");



    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }

    public void enemyAttack()
    {
        
        if (gameObject.layer == enemyLayer)
        {
//            Debug.Log(gameObject.name);
          if (gameObject.GetComponent<Enemy_0>().atacking == true)
        {
            if (Math.Abs(gameObject.transform.position.x - Player.transform.position.x) <= dist_dano)
            {
                
                    Player.GetComponent<playerController>().PerdeVida(dano);
                    Vector2 v = Player.GetComponent<Rigidbody2D>().velocity;
                    gameObject.GetComponent<Enemy_0>().hitsound();
                    v.x = Player.GetComponent<playerController>().lastHdirection * -2f;
                    v.y = 2f;
                    Player.GetComponent<Rigidbody2D>().velocity = v;

                }

            }
        }
    }
    

    void OnTriggerEnter2D(Collider2D colisor)
    {

        //Ataque do player.
        if (gameObject.layer == weaponLayer) { 
        //Se a colisão for com o inimigo.
        if (colisor.gameObject.layer == enemyLayer)
        {
               
            int dir;
            //Tira vida do inimigo.
            
            var inimigo = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
            
            inimigo.PerdeVida(dano);
                colisor.gameObject.GetComponent<Enemy_0>().damaged();

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
        }
        
                //Se for tiro.
                if (gameObject.layer == tiroLayer)
                {
                    //Se a colisao não for com o player.
                    if (colisor.gameObject.layer != playerLayer)
                    {
                if (colisor.gameObject.layer == enemyLayer)
                {
                    colisor.gameObject.GetComponent<Enemy_0>().damaged();
                    int dir;
                    
                    Vector2 Position = colisor.gameObject.transform.position;
                    if (colisor.gameObject.GetComponent<Enemy_0>().dir >= 0)
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }

                    Position.x += dir * -0.3f;

                    


                    colisor.gameObject.GetComponentInChildren<vidaObjeto>().PerdeVida(dano);
                    
                    colisor.gameObject.GetComponent<Rigidbody2D>().MovePosition(Position);

                    
                }
                        //Se destroiAtacante tiver habilitado.
                        if (destroiAtacante)
                        {
                            //destroi o atacante.
                            Destroy(gameObject);
                        }

                    }

                }
                
         
    }





}
