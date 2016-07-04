using UnityEngine;
using System.Collections;

public class collectItem : MonoBehaviour {

	public int playerLayer;
    private GameObject GM;

    // Use this for initialization
    void Start () {
		playerLayer = LayerMask.NameToLayer("Player");
        GM = GameObject.Find("GM");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D colisor)
	{
		if (colisor.gameObject.layer == LayerMask.NameToLayer("Floor"))
		{
			gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
		}
		if (colisor.gameObject.layer == playerLayer) {
			switch (gameObject.GetComponentInChildren<SpriteRenderer> ().sprite.name) {
			case "meat":
				colisor.gameObject.GetComponent<MyItems> ().meat++;
				DestroyObject (gameObject);
				break;
			case "salmon":
				colisor.gameObject.GetComponent<MyItems> ().salmon++;
				DestroyObject (gameObject);
				break;
			case "pizza":
				colisor.gameObject.GetComponent<MyItems> ().pizza++;
				DestroyObject (gameObject);
				break;
			case "beer":
				colisor.gameObject.GetComponent<MyItems> ().beer++;
				DestroyObject (gameObject);
				break;
			case "bread":
				colisor.gameObject.GetComponent<MyItems> ().bread++;
				DestroyObject (gameObject);
				break;
			case "cheese":
				colisor.gameObject.GetComponent<MyItems> ().cheese++;
				DestroyObject (gameObject);
				break;
			case "coin":
				colisor.gameObject.GetComponent<MyItems> ().ganhaGold(10);
				DestroyObject (gameObject);
				break;
			case "map":
                GM.GetComponent<GameManager>().GameEnd = true;
				DestroyObject (gameObject);
				break;
			case "chest":
				colisor.gameObject.GetComponent<MyItems> ().ganhaGold(100);
				DestroyObject (gameObject);
				break;
			case "fire":
				colisor.gameObject.GetComponent<MyItems> ().fireRune += 5;
				DestroyObject (gameObject);
				break;
			case "wind":
				colisor.gameObject.GetComponent<MyItems> ().windRune += 5;
				DestroyObject (gameObject);
				break;
			case "water":
				colisor.gameObject.GetComponent<MyItems> ().freezeRune += 5;
				DestroyObject (gameObject);
				break;
			}
		}
	}
}
