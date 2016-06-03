﻿using UnityEngine;
using System.Collections;

public class vidaObjeto : MonoBehaviour {


   
    public int maxVida;
    private int vidaAtual;
    public string nameIA;



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

    public void ganhaVida(int vida)
    {
        vidaAtual = vida;
        animator.SetInteger("lifeSprite", vidaAtual * 12 / maxVida);
    }
   

    //barraVida.GetComponent<GUIText>().
    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            animator.SetInteger("lifeSprite", 0);

            StartCoroutine(dead());

        }

        animator.SetInteger("lifeSprite", vidaAtual * 12 / maxVida);
        

     
    }

    //Melhor morrer do que perder a vida.
    IEnumerator dead()

    {
        (gameObject.transform.parent.gameObject.GetComponent(nameIA) as mobIA).dead();
        yield return new WaitForSeconds(5f);
        //chama o contador de vidas, se chegar a 0 destroi o objeto
        gameObject.transform.parent.gameObject.GetComponent<rebirthMob>().death();
        
    }



    }
