using UnityEngine;
using System.Collections;

public class bloodmaker : MonoBehaviour {

    public GameObject blood2;
    private blood tempBlood;


    public static blood Create(GameObject blood, Vector3 temp,Transform transform)
    {
        
        GameObject newObject = Instantiate(blood, temp, transform.rotation) as GameObject;
        blood yourObject = newObject.GetComponent<blood>();
        //do additional initialization steps here
        return yourObject;
    }


    public void createBlood(int tipo)
    {
        if (tipo > 0)
        {
            Vector3 temp = transform.position;
            temp.z += 3;
           
            tempBlood = Create(blood2,temp,transform);
            tempBlood.setBlood(tipo);
        }

    }
}
