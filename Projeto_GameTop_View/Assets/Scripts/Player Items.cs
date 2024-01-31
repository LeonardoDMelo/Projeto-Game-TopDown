using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{ 
    [Header("Amounts")]
    public int totalWood;
    public int carrots;
    public float currentlWater;
    public int fishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float woodLimit = 8;
    public float carrotLimit = 5;
    public float fishesLimt = 3;

    public void WaterLimit(float water)
    {
        if(currentlWater <= waterLimit) 
        {
            currentlWater += water; 
        }
    }
}
