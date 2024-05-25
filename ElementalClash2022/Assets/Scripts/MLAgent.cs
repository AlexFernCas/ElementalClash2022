using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class MLAgent : Agent
{
    public GameObject gMaster;
    public Player mlAgent;
    private BonusManager bonusManager;
    private GameMaster gameMaster;
    private PlayerUnit [] playerUnits;
    private MLAgentUnit [] mlAgentUnits;
    public Directioner rightDirectioner;
    public Directioner rightTopDirectioner;
    public Directioner rightBottomDirectioner;
    public Directioner leftCenterDirectioner;
    public int lastPlayerScore;
    public int lastMLAgentscore;

    void Start()
    {
        lastMLAgentscore = 0;
        lastPlayerScore = 0;
        bonusManager = gMaster.GetComponent<BonusManager>();
        gameMaster = gMaster.GetComponent<GameMaster>();

    }
    
    void Update()
    {
        AddReward(0.001f);
        CheckReward();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        /*bool leftDirectioner = gameMaster.GetLeftDirectioner();
        bool leftBottomDirectioner = gameMaster.GetLeftBottomDirectioner();
        bool leftTopDirectioner = gameMaster.GetLeftTopDirectioner();
        bool leftCenterDirectioner = gameMaster.GetLeftCenterDirectioner();
        bool rightDirectioner = gameMaster.GetRightDirectioner();
        bool rightBottomDirectioner = gameMaster.GetRightBottomDirectioner();
        bool rightTopDirectioner = gameMaster.GetRightTopDirectioner();
        bool rightCenterDirectioner = gameMaster.GetRightCenterDirectioner();

        sensor.AddObservation(leftDirectioner);
        //sensor.AddObservation(leftBottomDirectioner);
        //sensor.AddObservation(leftTopDirectioner);
        //sensor.AddObservation(leftCenterDirectioner);
        //sensor.AddObservation(rightDirectioner);
        //sensor.AddObservation(rightBottomDirectioner);
        //sensor.AddObservation(rightTopDirectioner);
        //sensor.AddObservation(rightCenterDirectioner);*/
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        int actionSelected = actions.DiscreteActions[0];
        switch (actionSelected)
        {
            case 0:
                ChangeRightDirectioner();
                break;

            case 1:
                ChangeRightBottomDirectioner();
                break;

            case 2:
                ChangeRightTopDirectioner();
                break;
            
            case 3:
                ChangeLeftCenterDirectioner();
                break;
            
            case 4:
                UseWallBonus();
                break;

            case 5:
                UseDuplicateBonus();
                break;

            case 6:
                UseThreeSegBonus();
                break;
        }
    }

    public void CheckReward(){
        if (gameMaster.pointsCounter.GetPlayerScore() != lastPlayerScore)
        {
            lastPlayerScore++;
            AddReward(-5f);
            EndEpisode();
        }
        else if(gameMaster.pointsCounter.GetMLAgentScore() != lastMLAgentscore)
        {
            lastMLAgentscore++;
            AddReward(10f);
            EndEpisode();
        }
    }

    public void ChangeRightDirectioner()
    {
        rightDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightDirectioner();
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightTopDirectioner();
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner.OnClickDirectioner();
        gameMaster.ChangeRightBottomDirectioner();
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner.OnClickDirectioner();
        gameMaster.ChangeLeftCenterDirectioner();
    }

    public void UseWallBonus()
    {
            bonusManager.MlAgentWallBonus();
            AddReward(5f);
    }

    public void UseThreeSegBonus()
    {
            bonusManager.MlAgentUseThreeSegBonus();
    }

    public void UseDuplicateBonus()
    {
            bonusManager.MlAgentDuplicateBonus();
    }
    public void SimulateAction (int number)
    {
        switch (number)
        {
            case 0:
                ChangeRightDirectioner();
                break;

            case 1:
                ChangeRightBottomDirectioner();
                break;

            case 2:
                ChangeRightTopDirectioner();
                break;
            
            case 3:
                ChangeLeftCenterDirectioner();
                break;
        }
    }

    public void SimulateBonus (int number)
    {
        switch (number)
        {
            case 0:
                bonusManager.MlAgentWallBonus();
                break;

            case 1:
                bonusManager.MlAgentDuplicateBonus();
                break;

            case 2:
                bonusManager.MlAgentUseThreeSegBonus();
                break;
        }
    }
}
