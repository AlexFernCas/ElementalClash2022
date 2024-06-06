using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controler : MonoBehaviour
{
    public Simulator simulator;
    private string position;

    void Awake ()
    {
        if (gameObject.tag == "Top"){
            position = "Top";
        } else
        {
            position = "Bot";
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Fire_Left")){
            simulator.AddFire(position);
        }
        else if (collision.gameObject.CompareTag("Water_Left")){
            simulator.AddWater(position);
        }
        else if (collision.gameObject.CompareTag("Wind_Left")){
            simulator.AddWind(position);
        }
        else if (collision.gameObject.CompareTag("Earth_Left")){
            simulator.AddEarth(position);
        }
    }
}
