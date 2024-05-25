using UnityEngine;

public class PlayerUnit : MonoBehaviour
{

    void Start()
    {
        transform.rotation = Quaternion.Euler(90f, 90f, 0f);
    }
}
