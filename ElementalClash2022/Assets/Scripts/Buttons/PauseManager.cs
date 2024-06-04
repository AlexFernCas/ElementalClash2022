using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton;
    public GameObject camera;

    AudioListener cameraListener;

    void Start()
    {
        pauseButton.SetActive(true);
        gameObject.SetActive(false);
        cameraListener = camera.GetComponent<AudioListener>();
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
        if (cameraListener.enabled)
        {
            cameraListener.enabled = false;
        } 
        else
        {
            cameraListener.enabled = true;
        }
    }
}