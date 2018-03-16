using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour 
{
    public PlayerOwned owner;

    public void Start()
    {
        owner.setOwner(GetComponent<Player>());
    }
}
