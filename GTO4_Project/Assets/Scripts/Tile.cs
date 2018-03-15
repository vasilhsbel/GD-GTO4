using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public bool emptyTile;

    public void Start()
    {
        emptyTile = true;
    }

    public void OnTriggerStay()
    {
        this.emptyTile = false;
    }

    
    public void OnTriggerExit()
    {
       this.emptyTile = true;
    }   
    

}
