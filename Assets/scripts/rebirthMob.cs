using UnityEngine;
using System.Collections;

public class rebirthMob : MonoBehaviour
{

    public int vidas;
    public string nameIA;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    public void death()
    {
        if (vidas < 1)
        {
            StartCoroutine(destroy());
        }
        else
        {
            vidas--;
            gameObject.GetComponentInChildren<vidaObjeto>().ganhaVida(gameObject.GetComponentInChildren<vidaObjeto>().maxVida);
            (gameObject.GetComponent(nameIA) as mobIA).live();
        }
    }

    IEnumerator destroy()
    {
        gameObject.GetComponent<dropItem>().death();
        yield return new WaitForSeconds(1);
        DestroyObject(gameObject);
    }
}
