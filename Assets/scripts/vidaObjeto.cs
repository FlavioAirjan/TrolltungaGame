using UnityEngine;
using System.Collections;

public class vidaPlayer : MonoBehaviour {


   
    public int maxVida;
    private int vidaAtual;


    private Animator animator;

    // Use this for initialization
    void Start () {

       
        //Vida
        vidaAtual = maxVida;
        animator = gameObject.GetComponent<Animator>();
        animator.SetInteger("lifeSprite",12);
    }

    // Update is called once per frame
    void Update () {

        

	}

   

    //barraVida.GetComponent<GUIText>().
    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            animator.SetInteger("lifeSprite", 0);
           
            DestroyObject(gameObject.transform.parent.gameObject);
        }

        animator.SetInteger("lifeSprite", vidaAtual * 12 / maxVida);
        

     
    }

 

}
