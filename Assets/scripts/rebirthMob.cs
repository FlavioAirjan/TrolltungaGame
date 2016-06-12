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
			Vector3 t = gameObject.GetComponentInChildren<vidaObjeto> ().transform.position;
			t.z = 0;
			gameObject.GetComponentInChildren<vidaObjeto> ().transform.position = new Vector3(t.x, t.y, t.z);
            gameObject.GetComponentInChildren<vidaObjeto>().ganhaVida(gameObject.GetComponentInChildren<vidaObjeto>().maxVida);
            (gameObject.GetComponent(nameIA) as mobIA).live();
        }
    }

    IEnumerator destroy()
    {
        gameObject.GetComponent<dropItem>().death();
        yield return new WaitForSeconds(5);
        DestroyObject(gameObject);
    }
}
