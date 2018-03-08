using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour {

    public int ammount;
    public string resourceName;
    public int maxValue;

    public delegate void OnVariableChangeHandler();

    public event OnVariableChangeHandler OnVariableChange;

    /*
    public int getAmmount()
    {
        return ammount;
    }

    public void setMax(int value)
    {
        maxValue = value;
    }

    public int getMax()
    {
        return maxValue;
    }

    public string getName()
    {
        return resourceName;
    }

    public void setName(string input)
    {
        resourceName = input;
    }
    */

    public void reduceAmmount(int value)
    {
        ammount -= value;
        OnVariableChange();
    }

    public void increaseAmmount(int value)
    {
        ammount += value;
        OnVariableChange();
    }

    
}

