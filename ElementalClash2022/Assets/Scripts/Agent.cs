using UnityEngine;
//using Unity.MLAgents;
//using Unity.MLAgents.Sensors;
//using Unity.MLAgents.Actuators;

public class Agent : MonoBehaviour
{
    public Directioner rightDirectioner;
    public Directioner rightTopDirectioner;
    public Directioner rightBottomDirectioner;
    public Directioner leftCenterDirectioner;
    public Player mlAgent;
    public BonusManager bonusManager;
    private GameMaster gameMaster;
    private PlayerUnit [] playerUnits;
    private MLAgentUnit [] mlAgentUnits;
    public int lastPlayerScore;
    public int lastMLAgentscore;

    void Start()
    {
       
    }
    
    /*    public override void CollectObservations(VectorSensor sensor)
    {
        bool leftDirectioner = gameMaster.GetLeftDirectioner();
        bool leftBottomDirectioner = gameMaster.GetLeftBottomDirectioner();
        bool leftTopDirectioner = gameMaster.GetLeftTopDirectioner();
        bool leftCenterDirectioner = gameMaster.GetLeftCenterDirectioner();
        bool rightDirectioner = gameMaster.GetRightDirectioner();
        bool rightBottomDirectioner = gameMaster.GetRightBottomDirectioner();
        bool rightTopDirectioner = gameMaster.GetRightTopDirectioner();
        bool rightCenterDirectioner = gameMaster.GetRightCenterDirectioner();
    

        sensor.AddObservation(leftDirectioner);
        sensor.AddObservation(leftBottomDirectioner);
        sensor.AddObservation(leftTopDirectioner);
        sensor.AddObservation(leftCenterDirectioner);
        sensor.AddObservation(rightDirectioner);
        sensor.AddObservation(rightBottomDirectioner);
        sensor.AddObservation(rightTopDirectioner);
        sensor.AddObservation(rightCenterDirectioner);
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

            case 7:
                SetFireElement();
                break;
            
            case 8:
                SetWaterElement();
                break;

            case 9:
                SetWindElement();
                break;

            case 10:
                SetEarthElement();
                break;
        }
    }

    public void CheckReward(){
        if (gameMaster.pointsCounter.GetPlayerScore() != lastPlayerScore)
        {
            lastPlayerScore++;
            //AddReward(-5f);
            //EndEpisode();
        }
        else if(gameMaster.pointsCounter.GetMLAgentScore() != lastMLAgentscore)
        {
            lastMLAgentscore++;
            //AddReward(10f);
            //EndEpisode();
        }
    }
*/
    public void ChangeRightDirectioner()
    {
        rightDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightDirectioner();
    }

    public void ChangeRightTopDirectioner()
    {
        rightTopDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightTopDirectioner();
    }

    public void ChangeRightBottomDirectioner()
    {
        rightBottomDirectioner.OnClickDirectioner();
        GameMaster.Instance.ChangeRightBottomDirectioner();
    }

    public void ChangeLeftCenterDirectioner()
    {
        leftCenterDirectioner.OnClickDirectioner();
        gameMaster.ChangeLeftCenterDirectioner();
    }

    public void UseWallBonus()
    {
            bonusManager.MlAgentWallBonus();
    }

    public void UseThreeSegBonus()
    {
            bonusManager.MlAgentUseThreeSegBonus();
    }

    public void UseDuplicateBonus()
    {
            bonusManager.MlAgentDuplicateBonus();
    }

    public void SetFireElement()
    {
        mlAgent.SetFireElement();
    }

    public void SetWaterElement()
    {
        mlAgent.SetWaterElement();
    }

    public void SetWindElement()
    {
        mlAgent.SetWindElement();
    }

    public void SetEarthElement()
    {
        mlAgent.SetEarthElement();
    }
}
