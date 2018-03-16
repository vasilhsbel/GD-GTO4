using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Player> myPlayers;

    [SerializeField]private int currentPlayer = 0;

    public void Start()
    {
        for (int i = 0; i < myPlayers.Count; i++)
        {
            myPlayers[i].endTurn();
        }
        myPlayers[0].startTurn();
    }

    public void nextTurn()
    {
        myPlayers[currentPlayer].endTurn();
        currentPlayer++;
        if(currentPlayer>=myPlayers.Count)
        currentPlayer=0;
        myPlayers[currentPlayer].startTurn();
    }

    public Player getPlayer()
    {
        return myPlayers[currentPlayer];
    }
	
}
