using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class bloodBack : MonoBehaviour {
    public Sprite[] sprites;
    public float animationSpeed;
    public bool end;
    public AudioClip source;
    // Use this for initialization
    void Start () {
        end = false;
    }

    void DActiveAllObjects()
    {
        GameObject[] gameObjects= GameObject.FindGameObjectsWithTag("Enemy");
        for (var i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(false);
        }
    }

    public void bloodStart()
    {
        // GameObject.Find("GM").GetComponent<AudioSource>().Stop();
        GameObject.Find("GM").GetComponent<AudioSource>().enabled = true;
        GameObject.Find("GM").GetComponent<AudioSource>().clip = source;
        GameObject.Find("GM").GetComponent<AudioSource>().Play();
        DActiveAllObjects();
        GameObject.Find("Player").GetComponent<playerController>().pause = true;
        transform.GetComponent<Image>().enabled = true;
        transform.GetComponentInChildren<Text>().enabled = true;
      end = false;
        StartCoroutine(nukeMethod());
    }

    public void bloodEnd()
    {
        
        GameObject.Find("Player").GetComponent<playerController>().pause = false;
        end = true;
        transform.GetComponent<Image>().enabled = false;
        transform.GetComponentInChildren<Text>().enabled = false;
    }

    public IEnumerator nukeMethod()
    {
        //destroy all game objects
        int i = 0;
        while (!end)
        {
            transform.GetComponent<Image>().sprite = sprites[i];
            i++;
            if(i>= sprites.Length)
            {
                i = 0;
            }
            yield return new WaitForSeconds(animationSpeed);
        }
    }
    // Update is called once per frame
    void Update () {
	
	}
}
