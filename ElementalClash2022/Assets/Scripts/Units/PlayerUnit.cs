using UnityEngine;

public class PlayerUnit : MonoBehaviour
{

    void Start()
    {
        if (gameObject.CompareTag("Fire_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        }
        else if (gameObject.CompareTag("Water_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 90f, 0f);
        }
        else if (gameObject.CompareTag("Wind_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 80f, 0f);
        }
        else if (gameObject.CompareTag("Earth_Left"))
        {
            transform.rotation = Quaternion.Euler(90f, 80f, 0f);
        }
    }
}
