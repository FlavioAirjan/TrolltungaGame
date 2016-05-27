using UnityEngine;
using System.Collections;

public class DaDano : MonoBehaviour {

    public int dano;
    public bool destroiAtacante;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        //Se a colisão for com o inimigo.
        if (colisor.gameObject.tag == "Inimigo")
        {
            //Tira vida do inimigo.
            var inimigo = colisor.gameObject.GetComponentInChildren<vidaPlayer>();
            inimigo.PerdeVida(dano);

        
        }

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

    }

    



}
