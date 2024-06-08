using UnityEngine;

public class MenuAudio : MonoBehaviour
{
    private static MenuAudio instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}