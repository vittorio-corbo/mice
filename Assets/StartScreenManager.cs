using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public AudioClip instructionsAudioClip;
    private AudioSource audioSource;
    private bool isInstructionsFinished = false;

    void Start()
    {
        // Get the AudioSource component from this GameObject
        audioSource = GetComponent<AudioSource>();

        // Set the audio clip to play
        audioSource.clip = instructionsAudioClip;

        // Play the audio clip
        audioSource.Play();

        // Start coroutine to check when the audio has finished playing
        StartCoroutine(CheckAudioFinished());
    }

    void Update()
    {
        // Check if the spacebar is pressed and the instructions audio has finished playing
        if (Input.GetKeyDown(KeyCode.Space) && isInstructionsFinished)
        {
            // Start the game
            StartGame();
        }
    }

    IEnumerator CheckAudioFinished()
    {
        // Wait until the audio clip has finished playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Set the flag to indicate that the audio has finished playing
        isInstructionsFinished = true;
    }

    void StartGame()
    {
        // Replace this with your code to start the game
        Debug.Log("Starting the game!");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
