using UnityEngine;
using System.Collections;

public class usaItem : MonoBehaviour {

    private GameObject Player;
    public int playerLayer;
    
    public int quantidadeGanha;

    //Tipo0: ganhaVida
    //Tipo1: ganhaMana
    //Tipo2: ganhaMana e ganhaVida
    //Tipo3: ganhaGold
    public int TipoItem;

    // Use this for initialization
    void Start () {

        Player = GameObject.Find("Player");
        playerLayer = LayerMask.NameToLayer("Player");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.layer == playerLayer)
        {
            switch (TipoItem)
            {
                case 0:
                    colisor.gameObject.GetComponent<playerController>().ganhaVida(quantidadeGanha);
                    DestroyObject(gameObject);
                    break;
                case 1:
                    colisor.gameObject.GetComponent<playerController>().ganhaMana(quantidadeGanha);
                    DestroyObject(gameObject);
                    break;
                case 2:
                    colisor.gameObject.GetComponent<playerController>().ganhaVida(quantidadeGanha);
                    colisor.gameObject.GetComponent<playerController>().ganhaMana(quantidadeGanha);
                    DestroyObject(gameObject);
                    break;
                case 3:
                    Debug.Log("Gold ainda não implementado.");
                    break;
                default:
                    break;

            }

        }
    }
}
