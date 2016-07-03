using UnityEngine;
using System.Collections;

public class blood : MonoBehaviour {

    public int tipo;
    public float[] duracao=new float[4];
    private bool destroi;
    public GameObject bloodFloor;
    public Sprite[] spritesBlood;
    // Use this for initialization
    void Start () {
        //Debug.Log(tipo);
        
    }

    public void setBlood(int ntipo,bool flipx)
    {
        if (ntipo<duracao.Length+1) {
            tipo = ntipo;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            if (tipo!=3)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = !flipx;
            }else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = flipx;
            }
            
            gameObject.GetComponent<Animator>().enabled = true;
            gameObject.GetComponent<Animator>().SetInteger("tipo", tipo);
            Vector3 temp = transform.position;
            temp.z = bloodFloor.GetComponent<Transform>().position.z;
            int sprite = Random.Range(0, spritesBlood.Length - 1);
            bloodFloor.GetComponent<SpriteRenderer>().sprite = spritesBlood[sprite];
            Instantiate(bloodFloor, temp, transform.rotation);

            DestroyObject(gameObject,duracao[tipo-1]);
        }
    }


    // Update is called once per frame
    void Update () {

    }
}
