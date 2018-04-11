using UnityEngine;

public class Player : MonoBehaviour 
{
    public Color Color;
    private bool isCurrentPlayer = false;

    public virtual void StartTurn()
    {
        gameObject.SetActive(true);
        isCurrentPlayer = true;
    }

    public virtual void EndTurn()
    {
        gameObject.SetActive(false);
        isCurrentPlayer = false;
    }

    public bool IsCurrentPlayer()
    {
        return isCurrentPlayer;
    }

    public bool IsHostile(Player other)
    {
        return this != other; // We'er hostile to anyone who is not us! Totally xenophobic.
    }

}
