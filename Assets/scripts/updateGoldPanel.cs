using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class updateGoldPanel : MonoBehaviour {

    private GameObject Player;
    

	// Use this for initialization
	void Start () {

        Player = GameObject.Find("Player");
    

	}
	
	// Update is called once per frame
	void Update () {

        gameObject.GetComponentInChildren<Text>().text =  Player.GetComponent<MyItems>().gold.ToString();
	
	}
}
