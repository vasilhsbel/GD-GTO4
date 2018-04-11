using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public List<Player> Players;
    public int currentPlayer = 0;

    public void Start()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].EndTurn();
        }
        Players[currentPlayer].StartTurn();
    }
    
    
    public void NextTurn()
    {
        Players[currentPlayer].EndTurn();
        currentPlayer++;
        if (currentPlayer >= Players.Count)
        {
            currentPlayer = 0;
        }
        Players[currentPlayer].StartTurn();
    }

    public Player GetCurrentPlayer()
    {
        return Players[currentPlayer];
    }

}
