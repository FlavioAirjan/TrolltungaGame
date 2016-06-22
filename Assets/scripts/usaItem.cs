using UnityEngine;
using System.Collections;

public class usaItem : MonoBehaviour {

   // private GameObject Player;
    public int playerLayer;
    
    public int quantidadeGanha;

    //Tipo0: ganhaVida
    //Tipo1: ganhaMana
    //Tipo2: ganhaMana e ganhaVida
    //Tipo3: ganhaGold
	//Tipo4: ganhaWind
	//Tipo5: ganhaFreeze
	//Tipo6: ganhaFire
    public int TipoItem;

    // Use this for initialization
    void Start () {

       // Player = GameObject.Find("Player");
        playerLayer = LayerMask.NameToLayer("Player");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D colisor)
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
                    colisor.gameObject.GetComponent<MyItems>().ganhaGold(quantidadeGanha);
                    DestroyObject(gameObject);
                    break;
				case 4:
					colisor.gameObject.GetComponent<MyItems>().buyRune(1,5);
					DestroyObject(gameObject);
					break;
				case 5:
					colisor.gameObject.GetComponent<MyItems>().buyRune(2,5);
					DestroyObject(gameObject);
					break;
				case 6:
					colisor.gameObject.GetComponent<MyItems>().buyRune(3,5);
					DestroyObject(gameObject);
					break;
				default:
                    break;

            }

        }
    }
}
