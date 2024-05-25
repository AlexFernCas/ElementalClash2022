using UnityEngine;

public class TakeBonus : MonoBehaviour
{
    private string tagName;
    public BonusManager bonusManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        tagName = collision.gameObject.tag;
        if (tagName.Contains("Left"))
        {
            bonusManager.UserTakedBonus();
            gameObject.SetActive(false);
        }
        else if (tagName.Contains("Right"))
        {
            bonusManager.MlAgentTakedBonus();
            gameObject.SetActive(false);
        }            
    } 

    public void SetBonusManager (BonusManager bonusManager)
    {
        this.bonusManager = bonusManager;
    }
}

