using UnityEngine;
using System.Collections;
using System;

public class DaDano : MonoBehaviour {

    public float dist_dano;

    public string nameIA;
    public int dano;
    public bool destroiAtacante;

    private int enemyLayer;
    private int playerLayer;
    private int tiroLayer;
    private int tiroBossLayer;
    private int weaponLayer;
    public mobIA mob;

    private GameObject Player;

    public int mobBlood;
    public int playerBlood;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        playerLayer = LayerMask.NameToLayer("Player");
        tiroBossLayer= LayerMask.NameToLayer("tiroTroll");
        tiroLayer = LayerMask.NameToLayer("Tiro");
        weaponLayer = LayerMask.NameToLayer("Weapon");
        mob= gameObject.GetComponent(nameIA) as mobIA;
    }

// Update is called once per frame
void Update()
    {

    
        
    }


    private bool Infront()
    {
        bool direita = !transform.GetComponentInChildren<SpriteRenderer>().flipX;
       float DistX= transform.position.x - Player.transform.position.x;
        if ((direita && DistX<=0)||(!direita &&DistX>=0))
        {
            return true;
        } else {
            return false;
        }
    }
    

    public bool enemyAttack()
    {
        
        if (gameObject.layer == enemyLayer)
        {
//            Debug.Log(gameObject.name);
          if (mob.isAtacking())
        {

                //Se o jogador estiver à uma distância menor ou igual à dist_dano e se o jogador estiver em uma altura que vá até a altura do colisor do inimigo.
                if (Vector2.Distance(transform.position, Player.transform.position) <= dist_dano) {//Math.Abs(gameObject.transform.position.x - Player.transform.position.x) <= dist_dano && Player.transform.position.y < gameObject.GetComponent<BoxCollider2D>().size.y)

                    //Se o jogador está verticalmente perto do inimigo.
                    if (Infront())
                    {

                        Player.GetComponent<playerController>().PerdeVida(dano);
                        Player.GetComponent<bloodmaker>().createBlood(playerBlood);
                        Vector2 v = Player.GetComponent<Rigidbody2D>().velocity;
                        mob.hitsound();

                        if (gameObject.transform.position.x - Player.GetComponent<Transform>().position.x > 0)
                        {
                            v.x = -2f;
                        }
                        else
                        {
                            v.x = 2f;
                        }


                        v.y = 2f;
                        Player.GetComponent<Rigidbody2D>().velocity = v;
                        return true;
                    }
                   
                }
            }
        }
        return false;
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        string ia;
        // ia = colisor.gameObject.GetComponent<mobSpawn>().myIA();
        //Se for tiro.
        if (gameObject.layer == tiroLayer)
        {
            //Se a colisao não for com o player.
            if (colisor.gameObject.layer != playerLayer)
            {
                if (colisor.gameObject.layer == enemyLayer)
                {
                    ia = colisor.gameObject.GetComponent<mobSpawn>().myIA();
                    (colisor.gameObject.GetComponent(ia) as mobIA).damaged();
                    int dir;

                    Vector2 Position = colisor.gameObject.transform.position;
                    if ((colisor.gameObject.GetComponent(ia) as mobIA).dirValue() >= 0)
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }

                    Position.x += dir * -0.3f;



                    colisor.gameObject.GetComponent<bloodmaker>().createBlood(mobBlood);
                    colisor.gameObject.GetComponentInChildren<vidaObjeto>().PerdeVida(dano);

                    colisor.gameObject.GetComponent<Rigidbody2D>().MovePosition(Position);
                    //Se destroiAtacante tiver habilitado.
                    if (destroiAtacante)
                    {
                        //destroi o atacante.
                        Destroy(gameObject);
                    }

                }


            }

        }
        else if (gameObject.layer == tiroBossLayer)
        {
            if (colisor.gameObject.layer == playerLayer)
            {
                Player.GetComponent<playerController>().PerdeVida(dano);
                Player.GetComponent<bloodmaker>().createBlood(playerBlood);
                Vector2 v = Player.GetComponent<Rigidbody2D>().velocity;

                if (gameObject.transform.position.x - Player.GetComponent<Transform>().position.x > 0)
                {
                    v.x = -2f;
                }
                else
                {
                    v.x = 2f;
                }


                v.y = 2f;
                Player.GetComponent<Rigidbody2D>().velocity = v;
                colisor.gameObject.GetComponent<bloodmaker>().createBlood(0);
                Destroy(gameObject);
            }


        }
    }
    

    void OnTriggerEnter2D(Collider2D colisor)
    {
        string ia;

        //Ataque do player.
        if (gameObject.layer == weaponLayer) { 
        //Se a colisão for com o inimigo.
        if (colisor.gameObject.layer == enemyLayer)
        {
                 ia= colisor.gameObject.GetComponent<mobSpawn>().myIA();
                int dir;
                //Tira vida do inimigo.
                colisor.gameObject.GetComponent<bloodmaker>().createBlood(mobBlood);
                var inimigo = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
            
            inimigo.PerdeVida(dano);
                (colisor.gameObject.GetComponent(ia) as mobIA).damaged();

                Vector2 position = colisor.gameObject.transform.position;

            if ((colisor.gameObject.GetComponent(ia) as mobIA).dirValue() >= 0)
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
                    ia = colisor.gameObject.GetComponent<mobSpawn>().myIA();
                    (colisor.gameObject.GetComponent(ia) as mobIA).damaged();
                    int dir;
                    
                    Vector2 Position = colisor.gameObject.transform.position;
                    if ((colisor.gameObject.GetComponent(ia) as mobIA).dirValue() >= 0)
                    {
                        dir = 1;
                    }
                    else
                    {
                        dir = -1;
                    }

                    Position.x += dir * -0.3f;


                    
                    colisor.gameObject.GetComponent<bloodmaker>().createBlood(mobBlood);
                    colisor.gameObject.GetComponentInChildren<vidaObjeto>().PerdeVida(dano);
                    
                    colisor.gameObject.GetComponent<Rigidbody2D>().MovePosition(Position);
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





}
