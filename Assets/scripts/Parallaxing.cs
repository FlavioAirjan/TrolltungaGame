using UnityEngine;
using System.Collections;

public class Parallaxing : MonoBehaviour {

    public Transform[] backgrounds;  //list with de backgrounds
    private float[] parallaxScales;  //the proportion of the cameras move the backgrounds
    public float smoothing;     //how smooth paralax is going to be. above 0.

    private Transform cam;
    private Vector3 previousCamPos;
    
    //called before start
    void Awake() {
        //setup camera reference
        cam = Camera.main.transform;

    }

	// Use this for initialization
	void Start () {
        previousCamPos = cam.position;

        parallaxScales = new float[backgrounds.Length];

        for (int i=0;i<backgrounds.Length;i++)  {
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }

	}
	
	// Update is called once per frame
	void Update () {

        for (int i=0;i<backgrounds.Length;i++)   {
            //the parallax is the opposite of the camera
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            //set a target x
            float backgrounTargetPosX = backgrounds[i].position.x + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgrounTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);

            //fade between
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position,backgroundTargetPos,smoothing*Time.deltaTime);

        }

        //set the position on the end
        previousCamPos = cam.position;

	}
}
