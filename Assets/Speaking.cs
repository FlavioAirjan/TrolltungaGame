using UnityEngine;
using System.Collections;

public class Speaking : MonoBehaviour {


    public string[] message;
    public GameObject DialogBoxText;

    // Use this for initialization
    void Start () {
        DialogBoxText.transform.parent.gameObject.SetActive(true);



        DialogBoxText.GetComponent<ImportText>().text = message;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
