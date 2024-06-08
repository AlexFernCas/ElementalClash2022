using System.Collections;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public static Simulator Instance;
    private int action;
    bool noChange;
    public Player mlAgent;
    public int[] elementsTop;
    public int[] elementsBot;
    readonly System.Random random = new System.Random();
    float elementSuccessProp;
    float elementFailProp;
    float directionerSuccesProp;

    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance); 
            Instance = this;
        }

        elementsTop = new int[4];
        elementsBot = new int[4];
        RandomElement();
        StartCoroutine(Action());

        if (Difficult.Instance.GetLevel() == Difficult.Level.Easy)
        {
            elementSuccessProp = 0.65f;
            elementFailProp = 0.15f;
            directionerSuccesProp = 0.65f;

        } else if (Difficult.Instance.GetLevel() == Difficult.Level.Medium)
        {
            elementSuccessProp = 0.75f;
            elementFailProp = 0.09f;
            directionerSuccesProp = 0.75f;

        } else if (Difficult.Instance.GetLevel() == Difficult.Level.Hard)
        {
            elementSuccessProp = 0.85f;
            elementFailProp = 0.05f;
            directionerSuccesProp = 0.90f;
        }
    }

    public IEnumerator Action()
    {
        while (true)
        {
            if (SumElements(elementsTop)+SumElements(elementsBot) >= 5)
            {
                BonusManager.Instance.MlAgentWallBonus();
            }
            
            double randomNum = random.NextDouble();

            if (randomNum < 0.15)
            {
                Debug.Log("1");
                GameMaster.Instance.ChangeLeftCenterDirectioner();
            }
            else if (randomNum < 0.5)
            {
                Debug.Log("2");
                GameMaster.Instance.ChangeRightBottomDirectioner();
            }
            else if (randomNum < 0.85)
            {
                Debug.Log("3");
                GameMaster.Instance.ChangeRightTopDirectioner();
            }
            else
            {
                Debug.Log("4");
                GameMaster.Instance.ChangeRightDirectioner();
            }

            if(!noChange)
            {
                RandomElement();
            }
            noChange = !noChange;
            yield return new WaitForSeconds(3f);
            BonusManager.Instance.MlAgentDuplicateBonus();
            BonusManager.Instance.MlAgentUseThreeSegBonus();
        }
    }

    void Defense()
    {
        int index = GetIndexOfMaxElement(elementsTop);
        double randomValue = random.NextDouble();

        if (SumElements(elementsTop) > SumElements(elementsBot))
        {
            if (randomValue < directionerSuccesProp && GameMaster.Instance.GetRightDirectioner())
            {
                GameMaster.Instance.ChangeRightDirectioner();
            }
        } else {            
            if (randomValue < directionerSuccesProp && !GameMaster.Instance.GetRightDirectioner())
            {
                GameMaster.Instance.ChangeRightDirectioner();
            }
        }

        switch (index)
        {
            case 0:
                if (randomValue < elementSuccessProp)
                {
                    mlAgent.SetWaterElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp)                    
                {
                    mlAgent.SetFireElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp*2)
                {
                    mlAgent.SetWindElement();
                }
                else
                {
                    mlAgent.SetEarthElement();
                }
                break;

            case 1:
                if (randomValue < elementSuccessProp)
                {
                    mlAgent.SetEarthElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp)
                {
                    mlAgent.SetFireElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp*2)
                {
                    mlAgent.SetWindElement();
                }
                else
                {
                    mlAgent.SetWaterElement();
                }
                break;

            case 2:
                if (randomValue <  elementSuccessProp)
                {
                    mlAgent.SetFireElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp)
                {
                    mlAgent.SetWaterElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp*2)
                {
                    mlAgent.SetWindElement();
                }
                else
                {
                    mlAgent.SetEarthElement();
                }
                break;

            case 3:
                if (randomValue < elementSuccessProp)
                {
                    mlAgent.SetWindElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp)
                {
                    mlAgent.SetFireElement();
                }
                else if (randomValue < elementSuccessProp + elementFailProp*2)
                {
                    mlAgent.SetWaterElement();
                }
                else
                {
                    mlAgent.SetEarthElement();
                }
                break;
        }
    }

       public void AddFire(string position)
    {
        if (position == "Top")
        {
            elementsTop[0] = elementsTop[0] + 1;
            StartCoroutine(SubtractAfterDelay(0, "Top"));
        }
        else
        {
            elementsBot[0] = elementsBot[0] + 1;
            StartCoroutine(SubtractAfterDelay(0, "Bot"));
        }
        Defense();
    }

    public void AddWater(string position)
    {
        if (position == "Top")
        {
            elementsTop[1] = elementsTop[1] + 1;
            StartCoroutine(SubtractAfterDelay(1, "Top"));
        }
        else
        {
            elementsBot[1] = elementsBot[1] + 1;
            StartCoroutine(SubtractAfterDelay(1, "Bot"));
        }
        Defense();
    }

    public void AddWind(string position)
    {
        if (position == "Top")
        {
            elementsTop[2] = elementsTop[2] + 1;
            StartCoroutine(SubtractAfterDelay(2, "Top"));
        }
        else
        {
            elementsBot[2] = elementsBot[2] + 1;
            StartCoroutine(SubtractAfterDelay(2, "Bot"));
        }
        Defense();
    }

    public void AddEarth(string position)
    {
        if (position == "Top")
        {
            elementsTop[3] = elementsTop[3] + 1;
            StartCoroutine(SubtractAfterDelay(3, "Top"));
        }
        else
        {
            elementsBot[3] = elementsBot[3] + 1;
            StartCoroutine(SubtractAfterDelay(3, "Bot"));
        }
        Defense();
    }

    IEnumerator SubtractAfterDelay(int index, string position)
    {
        yield return new WaitForSeconds(4f);
        if (position == "Top")
        {
            if (elementsTop[index] >= 1)
            {
                elementsTop[index] -= 1;
            }
        }
        else
        {
            if (elementsBot[index] >= 1)
            {
                elementsBot[index] -= 1;
            }
        }
        Defense();
    }

    public int SumElements(int[] elements)
    {
        int sum = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            sum += elements[i];
        }
        return sum;
    }

    public int GetIndexOfMaxElement(int[] elements)
    {
        int maxIndex = 0;
        int maxValue = elements[0];

        for (int i = 1; i < elements.Length; i++)
        {
            if (elements[i] > maxValue)
            {
                maxValue = elements[i];
                maxIndex = i;
            }
        }

        return maxIndex;
    }

    public void Reset()
    {
        for (int i = 0; i < elementsTop.Length; i++)
        {
            elementsTop[i] = 0;
        }

        for (int i = 0; i < elementsBot.Length; i++)
        {
            elementsBot[i] = 0;
        }
    }

    void RandomElement()
    {
        int randomNumber = random.Next(0, 4);

        if (randomNumber == 0)
        {
            mlAgent.SetFireElement();
        }
        else if (randomNumber == 1)
        {
            mlAgent.SetWaterElement();
        }
        else if (randomNumber == 2)
        {
            mlAgent.SetWindElement();
        }
        else
        {
            mlAgent.SetEarthElement();
        }

    }

}
