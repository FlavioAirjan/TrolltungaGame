using UnityEngine;
using System.Collections;

public class tiro : MonoBehaviour {

    private GameObject player;

    public float duracaoTiro = 1.0f;
    private float direcao;
    private float xPos;
    private float yPos;
    private float zPos;
    public float velocidade;
  

	// Use this for initialization
	void Start () {

        player = GameObject.Find("Player");
        gameObject.transform.parent = player.transform;

        //o tiro sempre irá para o lado da ultima direcao que o player andou.
        direcao = gameObject.GetComponentInParent<playerController>().lastHdirection;
       

        yPos = gameObject.GetComponentInParent<playerController>().transform.position.y - 0.07f;
        xPos = gameObject.GetComponentInParent<playerController>().transform.position.x;
        
        velocidade = 1f;
        gameObject.transform.parent = null;
 
        
        if (direcao >= 0)
        {
            direcao = 1f;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;

        }
        else
        {

            direcao = -1f;
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
            //transform.eulerAngles = new Vector2(0, 0);
        }

        

        transform.position = new Vector2(xPos, yPos);
        DestroyObject(gameObject,duracaoTiro);
     
    }
	
	// Update is called once per frame
	void Update () {

        
        transform.Translate(direcao*Vector2.right * velocidade * Time.deltaTime);

	}
}
