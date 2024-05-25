using System.Collections;
using UnityEngine;

public class Duplicate : MonoBehaviour
{
    bool nextDuplicate;
    string tagName;
    int duplications;
    public BonusTranslation fireUnit;
    public BonusTranslation waterUnit;
    public BonusTranslation windUnit;
    public BonusTranslation earthUnit;

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
                Instantiate(fireUnit, transform.position, transform.rotation);          
            }
            else if (collision.gameObject.CompareTag("Water_Left"))
            {
                Instantiate(waterUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Wind_Left"))
            {
                Instantiate(windUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Earth_Left"))
            {
                Instantiate(earthUnit, transform.position, transform.rotation);            
            }
            
            duplications += 1;
            if (duplications >= 3)
            {
                gameObject.SetActive(false);   
            }
        }
        else if (tagName == "duplicateL" && nextDuplicate)
        {
            if (collision.gameObject.CompareTag("Fire_Right"))
            {
                Instantiate(fireUnit, transform.position, transform.rotation);          
            }
            else if (collision.gameObject.CompareTag("Water_Right"))
            {
                Instantiate(waterUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Wind_Right"))
            {
                Instantiate(windUnit, transform.position, transform.rotation);            
            }
            else if (collision.gameObject.CompareTag("Earth_Right"))
            {
                Instantiate(earthUnit, transform.position, transform.rotation);            
            }
            
            duplications += 1;
            if (duplications >= 3)
            {
                gameObject.SetActive(false);   
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
