using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseButton;

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
        AudioManager.Instance.Mute();
        CamaraAudioSource.Instance.Mute();
    }
}