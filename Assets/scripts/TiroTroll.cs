using UnityEngine;
using System.Collections;

public class TiroTroll : MonoBehaviour {

    private GameObject mob;

    public float duracaoTiro = 1.0f;
    private float direcao;
    private float xPos;
    private float yPos;
    private float zPos;
    public float velocidade;
    public float ditInit;


    // Use this for initialization
    void Start()
    {

        mob = GameObject.Find("TrollBoss");
        gameObject.transform.parent = gameObject.transform;

        //o tiro sempre irá para o lado da ultima direcao que o player andou.
        direcao = mob.GetComponent<TrollIA>().dir;


        yPos = mob.GetComponent<TrollIA>().transform.position.y - 0.07f;
        xPos = mob.GetComponent<TrollIA>().transform.position.x;

        velocidade = 1f;
        gameObject.transform.parent = null;


        if (direcao >= 0)
        {
            xPos = xPos + ditInit;
            direcao = 1f;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;

        }
        else
        {
            xPos = xPos - ditInit;
            direcao = -1f;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
            //transform.eulerAngles = new Vector2(0, 0);
        }



        transform.position = new Vector2(xPos, yPos);
        DestroyObject(gameObject, duracaoTiro);

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(direcao * Vector2.right * velocidade * Time.deltaTime);

    }
}
