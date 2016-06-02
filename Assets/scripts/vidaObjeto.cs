using UnityEngine;
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

    IEnumerator dead()

    {
        (gameObject.transform.parent.gameObject.GetComponent(nameIA) as mobIA).dead();
        yield return new WaitForSeconds(5f);
        DestroyObject(gameObject.transform.parent.gameObject);
    }



    }
