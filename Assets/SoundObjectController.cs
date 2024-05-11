using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundObjectController : MonoBehaviour
{
    // AudioSource m_MyAudioSource;
    //[SerializeField]  int pizza;//set you up babyyy
    [SerializeField] int position;//set you up babyyy
    [SerializeField] int phase;//set you up babyyy
    //[SerializeField] Camera camera = FindObjectOfType<Camera>();
    [SerializeField] Camera camera;
    [SerializeField] AudioSource source;

    //make this into a list
    [SerializeField] AudioClip[] audioClip;

    // [SerializeField] AudioClip[] audioClipFirst;
    // [SerializeField] AudioClip[] audioClipSecond;
    // [SerializeField] AudioClip[] audioClipThird;

    //[SerializeField] SoundObjectController[] branch;
    [SerializeField] GameObject[] branch;


    //public GameObject parentObject;

    //

    // Start is called before the first frame update
    void Start()
    {
        camera = FindObjectOfType<Camera>();

        Debug.Log(position);
        Debug.Log(this);
        camera.ObjectsChange(position, this);
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

    // public void SelectSound(){
    //     if (phase == 0){
    //         source.clip = audioClipFirst[0];
    //     }else if (phase == 0){
    //         //choose between 3
    //         source.clip = audioClipSecond[0];
    //         source.clip = audioClipSecond[0];
    //         source.clip = audioClipSecond[0];

    //     }
    //     // source.outputAudioMixerGroup = clip;
    //     source.Stop();
    //     //audio. = otherClip;

    // }


    public void SelectObject(){
        //maybe play sfx

        //change to object



        //DESTROY OTHER 2
        SoundObjectController[] objectsOfKind = FindObjectsOfType<SoundObjectController>();

        foreach (SoundObjectController objOfKind in objectsOfKind){
            
            // if (objOfKind.gameObject != this){
            if (objOfKind.gameObject != gameObject){
                Debug.Log("pizza");
                Destroy(objOfKind.gameObject);
            }

        }

        

        //activate my children
        foreach (GameObject leaves in branch){
            //Debug.Log("how many times?");

            leaves.SetActive(true);   
            //leaves.parent = null;
        }

        //KILL FATHER

        List<Transform> childrenList = new List<Transform>();

        // Add references to the children to the list
        foreach (Transform child in transform)
        {
            childrenList.Add(child);
        }


        foreach (Transform leaves in childrenList){
            //Debug.Log("BEEEEEE many times?");
            Debug.Log(leaves.name);

            //leaves.SetActive(true);   
            leaves.parent = null;
            //camera.left = (SoundObjectController) leaves;
        }


        //DESTROY SELF
        Destroy(gameObject);


    }
}
