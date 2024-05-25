using System.Collections;
using UnityEngine;

public class BonusManager : MonoBehaviour
{

    public GameObject bonusPrefab;
    public Player user;
    public Player mlAgent;
    public BonusButton threeSegBonusButton;
    public BonusButton wallBonusButton;
    public BonusButton duplicateBonusButton;
    public Wall userWall;
    public Wall mlAgentWall;
    public Duplicate userDuplicate;
    public Duplicate mlAgentDuplicate;
    public Transform bonusSpawnPoint;
    private int [] bonus;
    private int bonusTimer;
    private int bonusIndex;
    private int firstBonusTimer;
    private bool mlAgentDuplicateActive;
    private bool mlAgentWallActive;
    private bool mlAgentThreeSegActive;

    public void Awake()
    {
        mlAgentDuplicateActive = false;
        mlAgentWallActive = false;
        mlAgentThreeSegActive = false;
        bonusPrefab.SetActive(false);
        bonusTimer = 25;
        bonusIndex = 0;
        bonus = new int [] {0, 1, 2};
        Shuffle(bonus);
        StartCoroutine(BonusPrefab());
    }
    IEnumerator BonusPrefab()
    {
        while(true)
        {
            yield return new WaitForSeconds(bonusTimer);
            if (!bonusPrefab.activeInHierarchy)
            {
                AudioManager.Instance.PlayBonusSpawnSound();
                bonusPrefab.SetActive(true);
                BonusIndex();
            }
            yield return null;
        }
    }

    public void UserTakedBonus(){
        if (bonus[bonusIndex] == 0)
        {
            ActiveWallBonusButton();
        } 
        else if (bonus[bonusIndex] == 1)
        { 
            ActiveDuplicateBonusButton();
        }
        else if (bonus[bonusIndex] == 2)
        {
            ActiveThreeSegBonusButton();
        }
    }

    public void MlAgentTakedBonus(){
        if (bonus[bonusIndex] == 0)
        {
            mlAgentWallActive = true;
        } 
        else if (bonus[bonusIndex] == 1)
        { 
            mlAgentDuplicateActive = true;
        }
        else if (bonus[bonusIndex] == 2)
        {
            mlAgentThreeSegActive = true;
        }
    }

    private void BonusIndex()
    {
        bonusIndex++;
        if (bonusIndex >= bonus.Length) bonusIndex = 0;
    }

    void Shuffle<T>(T[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            int k = Random.Range(0, n--);
            T temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
    public void ActiveWallBonusButton()
    {
        if (!duplicateBonusButton.IsActive() && !threeSegBonusButton.IsActive())
        {
            wallBonusButton.SetActive(true);
        }
    }

    public void UserWallBonus()
    {
        wallBonusButton.SetActive(false);
        userWall.SetActive(true);
    }

    public void MlAgentWallBonus()
    {
        if (mlAgentWallActive)
        {
            mlAgentWallActive = false;
            mlAgentWall.SetActive(true);
        }
    }

    public void ActiveThreeSegBonusButton ()
    {
        if (!duplicateBonusButton.IsActive() && !wallBonusButton.IsActive())
        {
            threeSegBonusButton.SetActive(true);
        }
    }

    public void UserUseThreeSegBonus()
    {
        threeSegBonusButton.SetActive(false);
        StartCoroutine(ThreeSegBonus(user));
    }

    public void MlAgentUseThreeSegBonus()
    {
        if (mlAgentThreeSegActive)
        {
            mlAgentThreeSegActive = false;
            StartCoroutine(ThreeSegBonus(mlAgent));
        }
    }

    IEnumerator ThreeSegBonus (Player player)
    {
        player.unitsByWave = 6;
        player.spawnTimer = 0.25f;
        player.unitsCost = 5;
        yield return new WaitForSeconds(3f);
        player.unitsByWave = 3;
        player.spawnTimer = 0.5f;
        player.unitsCost = 10;
    }

    public void ActiveDuplicateBonusButton()
    {
        if (!threeSegBonusButton.IsActive() && !wallBonusButton.IsActive())
        {
           duplicateBonusButton.SetActive(true);
        }        
    }

    public void UserUseDuplicateBonus()
    {
        duplicateBonusButton.SetActive(false);
        userDuplicate.SetActive(true);
    }

    public void MlAgentDuplicateBonus()
    {
        if (mlAgentDuplicateActive)
        {
            mlAgentDuplicateActive = false;
            mlAgentDuplicate.SetActive(true);
        }
    }
}
