using System.Collections;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    bool nextDuplicate;
    string tagName;
    int duplications;
    public BonusTranslation userFireUnit;
    public BonusTranslation userWaterUnit;
    public BonusTranslation userWindUnit;
    public BonusTranslation userEarthUnit;

    void Start()
    {
        SetActive(false);
        tagName = gameObject.tag;
        duplications = 0;
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (tagName == "duplicateR" && nextDuplicate)
        {
            if (collision.gameObject.CompareTag("Fire_Left"))
            {
                Instantiate(userFireUnit, transform.position, transform.rotation);          
            }
            else if (collision.gameObject.CompareTag("Water_Left"))
            {
                Instantiate(userWaterUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Wind_Left"))
            {
                Instantiate(userWindUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Earth_Left"))
            {
                Instantiate(userEarthUnit, transform.position, transform.rotation);            
            }
            duplications += 1;
            if (duplications >= 3)
            {
                Destroy(gameObject);    
            }
        }
        nextDuplicate = !nextDuplicate;
    }

    public void SetActive(bool set)
    {
        gameObject.SetActive(set);
        nextDuplicate = true;
    }

}
