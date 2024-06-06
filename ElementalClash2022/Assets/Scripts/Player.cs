using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject [] unitsPrefab;
        public enum Element{
        Fire, 
        Water,
        Wind,
        Earth,
        None
        }

    public GameObject fireParticles;
    public GameObject waterParticles;
    public GameObject windParticles;
    public GameObject earthParticles;

    private Element currentElement;
    private int earthPower;
    private int firePower;
    private int waterPower;
    private int windPower;
    private int powerAdd;
    public int unitsByWave; 
    public int unitsCost;
    private int startTimer;
    public float spawnTimer;
    private int wavesTimer;
    private float powerTimer;
    private bool scored;

    void Awake()
    { 
        fireParticles.SetActive(false);
        waterParticles.SetActive(false);
        windParticles.SetActive(false);
        earthParticles.SetActive(false);
        startTimer = 5;
        spawnTimer = 0.5f;
        wavesTimer = 2;
        unitsByWave = 3;
        unitsCost = 10;
        powerTimer = 1;
        earthPower = 100;
        firePower = 100;
        waterPower = 100;
        windPower = 100;
        powerAdd = 2;
        scored = false;
        currentElement = Element.None;
        StartCoroutine(Spawn());
        StartCoroutine(AddAllPowers());
    }
    public IEnumerator Spawn ()
    {
        yield return new WaitForSeconds(startTimer);
        while (true)
        {
            if (scored) 
            {
                Scored();
                yield return new WaitForSeconds(wavesTimer);  
            }
                
            /*if (gameObject.CompareTag("Agent"))
            {
               RandomElement();
            }*/

            if (currentElement != Element.None)
            {
                for (int i = 0; i < unitsByWave; i++)
                {
                    SpawnUnit();
                    yield return new WaitForSeconds(spawnTimer);
                }
            } 
            else
            {
                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(wavesTimer);
        }
    }

    void SpawnUnit()
    {
        switch(currentElement)
        {
            case Element.Fire:
                if (firePower < unitsCost) return;
                firePower -= unitsCost;
                break;
            
            case Element.Water:
                if (waterPower < unitsCost) return;
                waterPower -= unitsCost;
                break;
            case Element.Wind: 
                if (windPower < unitsCost) return;
                windPower -= unitsCost;
                break;
            case Element.Earth:
                if (earthPower < unitsCost) return;
                earthPower -= unitsCost;
                break;
        }

        int index = GetElementIndex();
        Instantiate(unitsPrefab[index], transform.position, transform.rotation);
        AudioManager.Instance.PlayUnitSpawnSound(); 
        
    }

    public IEnumerator AddAllPowers()
    {
        while(true)
        {
            yield return new WaitForSeconds(powerTimer);
            AddFirePower(powerAdd);
            AddWaterPower(powerAdd);
            AddWindPower(powerAdd);
            AddEarthPower(powerAdd);
        }
    }

    public void RestartPower()
    {
        AddFirePower(100);
        AddWaterPower(100);
        AddWindPower(100);
        AddEarthPower(100);
    }
    public void Scored ()
    {
        scored = !scored;
    }

    public void SetFireElement()
    {
        waterParticles.SetActive(false);
        windParticles.SetActive(false);
        earthParticles.SetActive(false);
        fireParticles.SetActive(true);
        currentElement = Element.Fire;
    }

    public void AddFirePower(int power)
    {
        firePower += power;
        if (firePower > 100) firePower = 100;
    }

    public int GetFirePower(){
        return firePower;
    }

    public void SetWaterElement()
    {
        fireParticles.SetActive(false);
        windParticles.SetActive(false);
        earthParticles.SetActive(false);
        waterParticles.SetActive(true);
        currentElement = Element.Water;
    }

    public void AddWaterPower(int power)
    {
        waterPower += power;
        if (waterPower > 100) waterPower = 100;
    }

    public int GetWaterPower(){
        return waterPower;
    }

    public void SetWindElement()
    {
        waterParticles.SetActive(false);
        fireParticles.SetActive(false);
        earthParticles.SetActive(false);
        windParticles.SetActive(true);
        currentElement = Element.Wind;
    }

    public void AddWindPower(int power)
    {
        windPower += power;
        if (windPower > 100) windPower = 100;
    }

    public int GetWindPower(){
        return windPower;
    }
    public void SetEarthElement()
    {
        waterParticles.SetActive(false);
        windParticles.SetActive(false);
        fireParticles.SetActive(false);
        earthParticles.SetActive(true);
        currentElement = Element.Earth;
    }

    public void AddEarthPower(int power)
    {
        earthPower += power;
        if (earthPower > 100) earthPower = 100;
    }

    public int GetEarthPower(){
        return earthPower;
    }
    private int GetElementIndex()
    {
        return currentElement switch
        {
            (Element.Fire) => 0,
            (Element.Water) => 1,
            (Element.Wind) => 2,
            (Element.Earth) => 3,
            _ => -1,
        };
    }

    public bool HasElement()
    {
        return currentElement == Element.None;
    }
    void RandomElement()
    {
        int randomIndex = UnityEngine.Random.Range(0, 4);
        if (randomIndex == 0) {
            SetFireElement();
        } 
        else if (randomIndex == 1)
        {
            SetWaterElement();
        } 
        else if (randomIndex == 2)
        {
            SetWindElement();
        } else 
        {
            SetEarthElement();
        }
    }

    void ResetParticles ()
    {
        fireParticles.SetActive(false);
        waterParticles.SetActive(false);
        windParticles.SetActive(false);
        earthParticles.SetActive(false);
    }
}
