using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public int X;
    public int Y;

    public bool isEmpty;

    public void OnTriggerStay()
    {
        this.isEmpty = false;
    }

    public void OnTriggerExit()
    {
        this.isEmpty = true;
    }
}
