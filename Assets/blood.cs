using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

    public int tipo;
    public float[] duracao=new float[4];
    private bool destroi;
	// Use this for initialization
	void Start () {
        //Debug.Log(tipo);
        
    }

    public void setBlood(int ntipo)
    {
        if (ntipo<duracao.Length+1) {
            tipo = ntipo;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().SetInteger("tipo", tipo);
            DestroyObject(gameObject,duracao[tipo-1]);
        }
    }


    // Update is called once per frame
    void Update () {

    }
}
