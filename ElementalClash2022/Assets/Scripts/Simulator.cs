using System.Collections;
using UnityEngine;

public class Simulator : MonoBehaviour
{
    public static Simulator Instance;
    private int action;
    public MLAgent mlAgent;

    public int[] elementsTop;
    public int[] elementsBot;
    readonly System.Random random = new System.Random();

    void Start()
    {
        if (Instance != this)
        {
            Destroy(Instance); 
            Instance = this;
        }

        elementsTop = new int[4];
        elementsBot = new int[4];
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

        StartCoroutine(Action());
    }

    public IEnumerator Action()
    {
        while (true)
        {
            double randomNum = random.NextDouble();

            if (randomNum < 0.11)
            {
                mlAgent.ChangeLeftCenterDirectioner();
            }
            else if (randomNum < 0.51)
            {
                mlAgent.ChangeRightBottomDirectioner();
            }
            else if (randomNum < 0.90)
            {
                mlAgent.ChangeRightTopDirectioner();
            }
            else
            {
                mlAgent.ChangeRightDirectioner();
            }

            yield return new WaitForSeconds(4f);
        }
    }

    void Defense()
    {
        int index = GetIndexOfMaxElement(elementsTop);
        double randomValue = random.NextDouble();
        if (SumElements(elementsTop) > SumElements(elementsBot))
        {
            switch (index)
            {
                case 0:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;

                case 1:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetEarthElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetWaterElement();
                    }
                    break;

                case 2:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;

                case 3:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;
            }

            if (randomValue < 0.80f && GameMaster.Instance.GetRightDirectioner())
            {
                GameMaster.Instance.ChangeRightDirectioner();
            }
        }
        else if (SumElements(elementsTop) < SumElements(elementsBot))
        {
            switch (index)
            {
                case 0:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;

                case 1:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetEarthElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetWaterElement();
                    }
                    break;

                case 2:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;

                case 3:
                    if (randomValue < 0.65f)
                    {
                        mlAgent.SetWindElement();
                    }
                    else if (randomValue < 0.76f)
                    {
                        mlAgent.SetFireElement();
                    }
                    else if (randomValue < 0.88f)
                    {
                        mlAgent.SetWaterElement();
                    }
                    else
                    {
                        mlAgent.SetEarthElement();
                    }
                    break;
            }

            if (randomValue < 0.80f && !GameMaster.Instance.GetRightDirectioner())
            {
                GameMaster.Instance.ChangeRightDirectioner();
            }
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
}
