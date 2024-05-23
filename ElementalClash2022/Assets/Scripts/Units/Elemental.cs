using UnityEngine;

public class Elemental : MonoBehaviour
{
    private int live;
    private new string tag;
    private int damage;

    void Start()
    {
        live = 100;
        damage = 34;
        tag = gameObject.tag;
    }

    private void Damage(){
        live -= damage;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (tag)
        {
            case ("Fire_Left"):
                if (collision.gameObject.CompareTag("Water_Right") || 
                    collision.gameObject.CompareTag("Earth_Right") || 
                    collision.gameObject.CompareTag("Fire_Right"))
                {
                    AudioManager.Instance.PlayUnitDeadSound();
                    Destroy(gameObject);
                    return;
                } 
                else if (collision.gameObject.CompareTag("Wind_Right"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        AudioManager.Instance.PlayUnitDeadSound();
                        Destroy(gameObject);
                        return;
                    }
                }
                break;

            case ("Fire_Right"):
                if (collision.gameObject.CompareTag("Fire_Left") ||  
                    collision.gameObject.CompareTag("Earth_Left") ||
                    collision.gameObject.CompareTag("Water_Left"))
                {
                    AudioManager.Instance.PlayUnitDeadSound();
                    Destroy(gameObject);
                    return;
                }
                else if (collision.gameObject.CompareTag("Wind_Left"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        AudioManager.Instance.PlayUnitDeadSound();
                        Destroy(gameObject);
                        return;
                    }
                }
                break;

            case ("Water_Left"):
                if (collision.gameObject.CompareTag("Water_Right") || 
                collision.gameObject.CompareTag("Wind_Right") ||
                collision.gameObject.CompareTag("Earth_Right"))
                {
                    AudioManager.Instance.PlayUnitDeadSound();
                    Destroy(gameObject);
                    return;
                } 
                else if (collision.gameObject.CompareTag("Fire_Right"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                    AudioManager.Instance.PlayUnitDeadSound();
                    Destroy(gameObject);
                    return;
                    }
                }
                break;
            
            case ("Water_Right"):
                if (collision.gameObject.CompareTag("Water_Left") || 
                collision.gameObject.CompareTag("Wind_Left") ||
                collision.gameObject.CompareTag("Earth_Left"))
                {
                    Destroy(gameObject);
                    return;
                } 
                else if (collision.gameObject.CompareTag("Fire_Left"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        Destroy(gameObject);
                        return;
                    }
                }
                break;
            
            case ("Wind_Left"):
                if (collision.gameObject.CompareTag("Water_Right") || 
                collision.gameObject.CompareTag("Wind_Right") ||
                collision.gameObject.CompareTag("Fire_Right"))
                {
                    AudioManager.Instance.PlayUnitDeadSound();
                    Destroy(gameObject);
                    return;
                } 
                else if (collision.gameObject.CompareTag("Earth_Right"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        AudioManager.Instance.PlayUnitDeadSound();
                        Destroy(gameObject);
                        return;
                    }
                } 
                break;

            case ("Wind_Right"):
                if (collision.gameObject.CompareTag("Water_Left") || 
                collision.gameObject.CompareTag("Wind_Left") || 
                collision.gameObject.CompareTag("Fire_Left"))
                {
                    Destroy(gameObject);
                    return;
                } 
                else if (collision.gameObject.CompareTag("Earth_Left"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        Destroy(gameObject);
                        return;
                    }
                } 
                break;

            case ("Earth_Left"):
                if (collision.gameObject.CompareTag("Fire_Right") ||  
                collision.gameObject.CompareTag("Earth_Right") ||
                collision.gameObject.CompareTag("Wind_Right"))
                {
                    Destroy(gameObject);
                    return;
                }
                else if (collision.gameObject.CompareTag("Water_Right"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        Destroy(gameObject);
                        return;
                    }
                }
                break;

            case ("Earth_Right"):
                if (collision.gameObject.CompareTag("Fire_Left") ||  
                collision.gameObject.CompareTag("Earth_Left") ||
                collision.gameObject.CompareTag("Wind_Left"))
                {
                    Destroy(gameObject);
                    return;
                }
                else if (collision.gameObject.CompareTag("Water_Left"))
                {
                    Damage();
                    AudioManager.Instance.PlayUnitDamageSound();
                    if (live <= 0) 
                    {
                        Destroy(gameObject);
                        return;
                    }
                }
                break;
        } 
    }
}
