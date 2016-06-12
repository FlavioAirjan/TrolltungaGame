using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class newScene : MonoBehaviour {


    public float time;
    public string scene;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(changeScene());
    }



    IEnumerator changeScene()
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scene);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(scene);
        }
    }

}
