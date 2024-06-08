using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficult : MonoBehaviour
{
    public GameObject playButton;
    public GameObject tutorialButton;
    public GameObject exitButton;
    public GameObject easyButton;
    public GameObject mediumButton;
    public GameObject hardButton;
    public GameObject backButton;
    public static Difficult Instance;
    bool play;

    public enum Level{
        Easy,
        Medium,
        Hard
    }

    public Level level;

    void Start()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(Instance);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        play = false;

        easyButton.SetActive(false);
        mediumButton.SetActive(false);
        hardButton.SetActive(false);
        backButton.SetActive(false);
    }


    public void SetEasyLevel ()
    {
        level = Level.Easy;
    }

    public void SetMediumLevel ()
    {
        level = Level.Medium;
    }

    public void SetHardLevel ()
    {
        level = Level.Hard;
    }

    public bool GetPlay()
    {
        return play;
    }

    public void SetPlay()
    {
        play = !play;
        if (play)
        {
            easyButton.SetActive(true);
            mediumButton.SetActive(true);
            hardButton.SetActive(true);
            backButton.SetActive(true);
            playButton.SetActive(false);
            tutorialButton.SetActive(false);
            exitButton.SetActive(false);    
        } else
        {
            easyButton.SetActive(false);
            mediumButton.SetActive(false);
            hardButton.SetActive(false);
            backButton.SetActive(false);
            playButton.SetActive(true);
            tutorialButton.SetActive(true);
            exitButton.SetActive(true);   
        }
    }

    public Level GetLevel()
    {
        return level;
    }
}
