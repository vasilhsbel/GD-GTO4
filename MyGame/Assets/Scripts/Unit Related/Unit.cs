using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour 
{
    public PlayerOwned owner;
    private float unitSpeedX;
    private float unitSpeedZ;
    private float totalSteps;
    private float[] mySteps = new float[2];
    public Grid myGrid;



    public void Start()
    {
        //owner.setOwner(GetComponent<Player>());
        //unitSpeedX = myGrid.getXspeed(); 
        //unitSpeedZ = myGrid.getZspeed(); 
    }

    public void newTurn()
    {
        //Reset movement for turn
        mySteps[0] = unitSpeedX * 3; //Allow unit to move 3 Squares on the X 
        mySteps[1] = unitSpeedZ * 3; //Allow unit to move 3 Squares on the Z
        totalSteps = ((mySteps[0] / unitSpeedX) + (mySteps[1] / unitSpeedZ))/2;
    }

    public bool takeSteps(Tile targetTile)
    {
        float distance;
        Transform myLoc = this.GetComponentInParent<Transform>();
        distance = (Math.Abs((myLoc.position.x - targetTile.transform.position.x)/unitSpeedX)+ (Math.Abs(myLoc.position.z - targetTile.transform.position.z) / unitSpeedZ));

        if (distance < totalSteps)
        {
            totalSteps -= distance;
            return true;
        }
        return false;
    }
}
