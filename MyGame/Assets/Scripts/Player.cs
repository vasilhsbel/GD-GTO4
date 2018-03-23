using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Color color;
    public bool isDead;

    public void startTurn()
    {
        gameObject.SetActive(true);
    }

    public void endTurn()
    {
        gameObject.SetActive(false);
    }

}
