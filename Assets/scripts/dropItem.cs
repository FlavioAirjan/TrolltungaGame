using UnityEngine;
using System.Collections;

public class dropItem : MonoBehaviour {

    public Transform[] Itens;
    public float[] chance;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}

    public void death()
    {
        Vector3 position= transform.position;
        for (int i = 0; i < Itens.Length; i++) { 
        if (Random.value <= chance[i])
        {
				
				Instantiate(Itens[i], position, transform.rotation);
				position.x += Itens[i].GetComponent<BoxCollider2D>().size.x/2;
        }
    }
    }

}
