using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int X;
    public int Y;
    public int Z;

    public bool isEmpty;

    public void Update()
    {
        if (GetComponentInChildren<Unit>() != null)
        {
            isEmpty = false;
        }
        else
        {
            isEmpty = true;
        }
    }

    public void setCoordinates(int x, int y)
    {
        X = x;
        Y = y;
        Z = -(x + y);
    }

    public void OnTriggerStay()
    {
        this.isEmpty = false;
    }

    public void OnTriggerExit()
    {
        this.isEmpty = true;
    }
}
