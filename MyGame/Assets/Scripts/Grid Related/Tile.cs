using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int X;
    public int Y;
    public int Z;

    public bool isEmpty;

    public void setCoordinates(int y, int x)
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
