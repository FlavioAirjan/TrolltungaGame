using UnityEngine;
using System.Collections;

public class GUITextureAboveObject : MonoBehaviour {

    //public Transform target;
    public float xOffset;
    public float yOffset;
 
    private Vector2 wantedPos;

    private Vector3 acimaCabecaObjeto;
        
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        acimaCabecaObjeto = new Vector3(transform.parent.position.x + xOffset, transform.parent.position.y + yOffset, transform.parent.position.z);
        wantedPos = Camera.main.WorldToViewportPoint(acimaCabecaObjeto);
        transform.position = wantedPos;
    }
}
