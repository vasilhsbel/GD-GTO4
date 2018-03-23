using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOwned : MonoBehaviour
{
    public Player owner;

    public Renderer playerColorRenderer;

    public void setOwner(Player Owner)
    {
        owner = Owner;
        if (playerColorRenderer != null)
        {
            playerColorRenderer.material.color = owner.color;
        }
    }
}
