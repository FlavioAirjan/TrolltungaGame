using UnityEngine;
using System.Collections;

public class MyItems : MonoBehaviour {

    public int gold;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ganhaGold(int valor)
    {
        gold += valor;
    }
}
