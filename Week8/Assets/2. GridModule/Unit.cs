using System;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int MovementRange = 1;
    
    public void MoveTo(Cell target)
    {
        Cell myCell = GetComponentInParent<Cell>();

        if (Math.Abs((target.X + target.Y) - (myCell.X + myCell.Y)) <= MovementRange) // Check if the target Cell is within range;
        {
            if (!target.IsOccupied) // Check if it's not already occupied
            {
                transform.SetParent(target.transform, false); // Okay, ready to go!
                myCell.IsOccupied = false;
                target.IsOccupied = true;
            }
            else
            {
                Debug.LogWarning("Target Cell is occupied!");
            }
        }
        else
        {
            Debug.LogWarning("Unit is not in range!");
        }
    }

    public void Attack(Unit unit)
    {
        Debug.Log("Fancy Attack here!");
    }
}
