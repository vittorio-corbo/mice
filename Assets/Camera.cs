using System.Collections;
using System.Collections.Generic;
//using UnityEditor.PackageManager.Requests;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera : MonoBehaviour
{
    // Define the rotation amount
    public float rotationAmount = 45f;
    public int objSelected = 0;

    //[SerializeField] SoundObjectController cube;
    [SerializeField] public SoundObjectController left;
    [SerializeField] public SoundObjectController mid;
    [SerializeField] public SoundObjectController right;


    [SerializeField] AudioSource source;
    [SerializeField] AudioClip[] audioClips;

    public bool freeze = false;
    private bool reset = false;


    //OBJECTS
    [SerializeField] public GameObject crowbar;
    [SerializeField] public GameObject knife;
    [SerializeField] public GameObject gun;

    [SerializeField] public GameObject finger;
    [SerializeField] public GameObject pendant;
    [SerializeField] public GameObject bullet;
    

    [SerializeField] public GameObject blouse;
    [SerializeField] public GameObject picture;
    [SerializeField] public GameObject book;
    
    
    

    void Start(){
        crowbar.SetActive(false); 
        gun.SetActive(false); 
        knife.SetActive(false); 
        finger.SetActive(false); 
        pendant.SetActive(false); 
        bullet.SetActive(false); 
        blouse.SetActive(false); 
        picture.SetActive(false); 
        book.SetActive(false); 

        NewDay(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (freeze == false){
            // Check for left arrow key press
            if (Input.GetKeyDown(KeyCode.LeftArrow) && (objSelected != -1))
            {
                // Rotate the object to the left by the defined amount
                transform.Rotate(Vector3.up, -rotationAmount);
                StopObject();

                objSelected -= 1;
                PlayObject();
            }

            // Check for right arrow key press
            if (Input.GetKeyDown(KeyCode.RightArrow) && (objSelected != 1))
            {
                // Rotate the object to the right by the defined amount
                transform.Rotate(Vector3.up, rotationAmount);
                StopObject();

                objSelected += 1;
                PlayObject();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            // if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //CHANGE THIS TO SELECT

                //PlayObject();
                SelectObject();


            }
        }


        //KILL IT ALL
        if (reset == true){
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);


            }
        }
    }


    public void PlayObject(){
        if (objSelected == -1){
            left.PlaySound();

        } else if (objSelected == 0){
            mid.PlaySound();
        }else { // == 1
            right.PlaySound();
        }
    }

    public void StopObject(){
        if (objSelected == -1){
            left.StopSound();

        } else if (objSelected == 0){
            mid.StopSound();
        }else { // == 1
            right.StopSound();
        }
    }

    public void SelectObject(){
        Debug.Log("this happend");
        freeze = true;

        if (objSelected == -1){
            left.SelectObject();

        } else if (objSelected == 0){
            mid.SelectObject();
        }else { // == 1
            right.SelectObject();
        }
    }


    public void ObjectsChange(int pos, SoundObjectController soundObjectController){
        Debug.Log("pizza even?");
        Debug.Log(pos);
        Debug.Log(soundObjectController);
        if (pos == 0){
            left = soundObjectController;
        } else if (pos == 1){
            mid = soundObjectController;
        } else{
            right = soundObjectController;
        }
    }


    public void NewDay(int day){

        SpawnObjects(day); 

        StartCoroutine(HelperNewDay(day));
    }

    public void SpawnObjects(int day){
        if (day == 0){
            
            //Destroy(objOfKind.gameObject);

            crowbar.SetActive(true); 
            gun.SetActive(true); 
            knife.SetActive(true); 
            // crowbar.SetActive(true); 
            // crowbar.SetActive(true); 



        }else if (day == 1){
            //kill previous three
            Destroy(crowbar);
            Destroy(gun);
            Destroy(knife);

            //get new three
            finger.SetActive(true); 
            pendant.SetActive(true); 
            bullet.SetActive(true); 



        } else if (day == 2){
            //kill previous three
            Destroy(finger);
            Destroy(pendant);
            Destroy(bullet);

            //get new three
            blouse.SetActive(true); 
            picture.SetActive(true); 
            book.SetActive(true); 


        } else if (day == 3){
            //kill previous three
            Destroy(blouse);
            Destroy(picture);
            Destroy(book);

        }
    }


    public IEnumerator HelperNewDay(int day)
    {
        freeze = true;

        source.clip = audioClips[day];

        // Play the audio clip
        source.Play();

        // Wait until the audio clip is done playing
        while (source.isPlaying)
        {
            yield return null;
        }

        //ITS DONEEEEE
        Debug.Log(day);
        freeze = false;
        Debug.Log("MY MOMMA DID IT");
        if (day == 3){
            freeze = true;
            reset = true;
        } else if (day == 4){
            freeze = true;
            reset = true;
            Debug.Log("as we know as?");
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        // Return true to indicate that the sound has finished playing
        yield return true;
    }    
}
