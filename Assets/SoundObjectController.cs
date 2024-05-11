using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectController : MonoBehaviour
{
    // AudioSource m_MyAudioSource;
    [SerializeField]  int pizza;//set you up babyyy
    [SerializeField] AudioSource source;

    //make this into a list
    [SerializeField] AudioClip[] audioClip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(){
        // source.outputAudioMixerGroup = clip;
        source.clip = audioClip[0];
        source.Play();
        //audio. = otherClip;

    }
    public void StopSound(){
        // source.outputAudioMixerGroup = clip;
        source.Stop();
        //audio. = otherClip;

    }
}
