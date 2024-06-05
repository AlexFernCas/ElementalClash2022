using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ShowBoard()
    {
        SceneManager.LoadScene("GameBoard", LoadSceneMode.Single);
    }

    public void ShowTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ShowTutorialElemental()
    {
        SceneManager.LoadScene("TutorialElemental");
    }

    public void ShowTutorialBonus()
    {
        SceneManager.LoadScene("TutorialBonus");
    }
    
    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
