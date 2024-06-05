using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton;
    public CamaraAudioSource cameraAudio;
    public AudioManager audioManager;

    void Start()
    {
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void PauseGame()
    {

        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Mute ()
    {
        cameraAudio.Mute();
        audioManager.Mute();

        /*if (cameraListener.enabled)
        {
            //cameraListener.enabled = false;
        } 
        else
        {
           // cameraListener.enabled = true;
        }*/
    }
}