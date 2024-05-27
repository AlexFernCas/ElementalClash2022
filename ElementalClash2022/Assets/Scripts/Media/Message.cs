using UnityEngine;
using TMPro;

public class Message : MonoBehaviour
{
    public GameObject sceneL;

    SceneLoader sceneLoader;
    public TMP_Text text;
    private float countdownTime = 5f;
    public Player user;

    void Start()
    {
        InvokeRepeating("UpdateCountdown", 0f, 1f);
        sceneLoader = sceneL.GetComponent<SceneLoader>();
    }

    void Update()
    {

    }
    void UpdateCountdown()
    {
        countdownTime -= 1f;
        if (countdownTime <= 0)
        {
            text.text = "¡Comienza la partida!";
            CancelInvoke("UpdateCountdown"); 
            Invoke("NoElement", 2f);
        }
        else
        {
            text.text = "Tiempo restante: " + countdownTime.ToString("F0");
        }
    }

    public void PlayerScores()
    {
        text.enabled = true;
        text.text = "¡Has anotado un punto!";
        countdownTime = 5f;
        InvokeRepeating("UpdateCountdown", 2f, 1f);
    }

    public void MlAgentScores()
    {
        text.enabled = true;
        text.text = "¡El rival ha anotado un punto!";
        countdownTime = 5f;
        InvokeRepeating("UpdateCountdown", 2f, 1f);
    }

    public void PlayerWins ()
    {
        text.enabled = true;
        AudioManager.Instance.PlayPlayerWinsSound();
        text.text = "¡Enhorabuena! Has ganado";
        Invoke("ShowMenu", 5f);
    }

    public void MlAgentWins ()
    {
        text.enabled = true;
        AudioManager.Instance.PlayMLAgentWins();
        text.text = "¡Lástima! Has perdido";
        Invoke("ShowMenu", 5f);
    }

    public void NoElement ()
    {
        if (user.HasElement())
        {
            text.enabled = true;
            text.text = "¡Elige un elemento!";
            Invoke("HideMessage", 2f);
        }
        else{
            HideMessage();
        }
    }

    void HideMessage()
    {
        text.enabled = false; 
    }

    void ShowMenu()
    {
        sceneLoader.ShowMenu();
    }
}