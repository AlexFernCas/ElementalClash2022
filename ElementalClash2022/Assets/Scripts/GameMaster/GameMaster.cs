using UnityEngine;

public class GameMaster : MonoBehaviour
{
        public static GameMaster Instance;
        public Player user;
        public Player mlAgent;
        public Elemental[] elements;
        public PointsCounter pointsCounter;
        public bool leftDirectioner;
        public bool leftBottomDirectioner;
        public bool leftTopDirectioner;
        public bool leftCenterDirectioner;
        public bool rightTopDirectioner;
        public bool rightBottomDirectioner;
        public bool rightCenterDirectioner;
        public bool rightDirectioner;

    void Awake()
    {
        if (Instance != this)
        {
            Destroy(Instance); 
            Instance = this;
        }
        leftDirectioner = false;
        leftBottomDirectioner = false;
        leftTopDirectioner = false;
        leftCenterDirectioner = false;
        rightTopDirectioner = false;
        rightBottomDirectioner = false;
        rightCenterDirectioner = false;
        rightDirectioner = false;
    }

    public void UserScores ()
    {
        pointsCounter.playerScores();
        StopUnitSpawning();
        DestroyAllElementals();
        if (EndGame()) return;
        ResumeUnitSpawning();       
    }

    public void MLAgentScores()
    {
        pointsCounter.mlAgentScores();
        StopUnitSpawning();
        DestroyAllElementals();
        if (EndGame()) return;
        ResumeUnitSpawning();
    }

    public bool EndGame()
    {
        return pointsCounter.GetPlayerScore() >= 3 || pointsCounter.GetMLAgentScore() >= 3;
    }
    public void DestroyAllElementals()
    {
        elements = FindObjectsOfType<Elemental>();
        if (elements != null)
        {
            foreach (Elemental element in elements)
            {
            Destroy(element.gameObject);
            }
        }    
    }

    public void StopUnitSpawning()
    {
        user.StopAllCoroutines();
        user.Scored();
        mlAgent.StopAllCoroutines();
        mlAgent.Scored();
    }

    public void ResumeUnitSpawning()
    {
        user.StartCoroutine(user.Spawn());
        user.StartCoroutine(user.AddAllPowers());
        user.RestartPower();
        mlAgent.StartCoroutine(mlAgent.Spawn());
        mlAgent.StartCoroutine(mlAgent.AddAllPowers());
        mlAgent.RestartPower();
    }

    public void ChangeRightDirectioner ()
    {
        rightDirectioner = !rightDirectioner;
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner = !rightTopDirectioner;
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner = !rightBottomDirectioner;
    }

    public void ChangeRightCenterDirectioner()
    {
        rightCenterDirectioner = !rightCenterDirectioner;
    }

    public void ChangeLeftDirectioner()
    {
        leftDirectioner = !leftDirectioner;
    }
    public void ChangeLeftTopDirectioner()
    {
        leftTopDirectioner = !leftTopDirectioner;
    }

    public void ChangeLeftBottomDirectioner()
    {
        leftBottomDirectioner = !leftBottomDirectioner;
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner = !leftCenterDirectioner;
    }

    public bool GetLeftDirectioner()
    {
        return leftDirectioner;
    }

    public bool GetLeftTopDirectioner()
    {
        return leftTopDirectioner;
    }

    public bool GetLeftBottomDirectioner()
    {
        return leftBottomDirectioner;
    }

    public bool GetLeftCenterDirectioner()
    {
        return leftCenterDirectioner;
    }

    public bool GetRightDirectioner()
    {
        return rightDirectioner;
    }
    public bool GetRightTopDirectioner()
    {
        return rightTopDirectioner;
    }

    public bool GetRightBottomDirectioner()
    {
        return rightBottomDirectioner;
    }
    public bool GetRightCenterDirectioner()
    {
        return rightCenterDirectioner;
    }
  
}
