using UnityEngine;
using System.Collections;

public class stopMusic : MonoBehaviour {
    private AudioSource[] allAudioSources;
    bool sound;

	// Use this for initialization
	void Start () {
        sound = true;
	}
    
  
     void Awake()
    {
        allAudioSources = Resources.FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
    }

    void StopAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.enabled = false;
            

        }
    }
    void StartAllAudio()
    {
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.enabled=true;
        }
    }
    // Update is called once per frame
    void Update () {

        //para música com f9
        if (Input.GetKeyDown(KeyCode.F9))
        {
            if (GetComponent<AudioSource>().enabled == true)
            {
                GetComponent<AudioSource>().enabled = false;
            }else
            {
                GetComponent<AudioSource>().enabled = true;
            }
        }


        //para todos os sons com F8
        if (Input.GetKeyDown(KeyCode.F8))
        {
            if (sound)
            {
                sound = false;
                StopAllAudio();
            }else
            {
                sound = true;
                StartAllAudio();
            }
        }
    }
}
