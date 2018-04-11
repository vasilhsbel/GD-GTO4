using UnityEngine;

[RequireComponent(typeof(Unit))]
[RequireComponent(typeof(PlayerOwned))]
public class SelectableUnit : Selectable
{
    private Unit unit;
    private PlayerOwned ownerData;

    void Start()
    {
        unit = GetComponent<Unit>();
        ownerData = GetComponent<PlayerOwned>();

    }

    public Unit GetUnit()
    {
        return unit;
    }


    public override void OnSelect()
    {
        // Do a particle effect, an animation, a colour change.. anything really
    }

    public override void OnDeselect()
    {
        // Undo the above
    }

    public void GiveTarget(Selectable target)
    {
        // First we'll try to resolve 'target' as either a Unit or a Tile.
        SelectableCell targetCell = target as SelectableCell;
        
        SelectableUnit targetUnit;
        if (targetCell == null) // it's not a SelectableTile, maybe it's a SelectableUnit
        {
            targetUnit = target as SelectableUnit;
        }
        else if (targetCell.IsOccupied()) // it IS a SelectableTile, and it's occupied!
        {
            targetUnit = GetComponentInChildren<SelectableUnit>();
        }
        else // it is a non-occupied SelectableTile
        {
            unit.MoveTo(targetCell.GetCell());
            return;
        }

        if (targetUnit != null) // it is a SelectableUnit, try to attack it.
        {
            if (IsValidTarget(targetUnit))
            {
                unit.Attack(targetUnit.GetUnit()); // Let Unit figure out whether it's in range of weapon and such
            }
            else
            {
                Debug.Log("Other Unit not a valid target");
            }
        }
    }

    public bool CanBeSelected()
    {
        return ownerData.Owner.IsCurrentPlayer(); // Can be selected if it's the owner's turn.
    }

    public bool IsValidTarget(SelectableUnit other)
    {
        if (!ownerData.IsHostile(other.ownerData))
        {
            return false;
        }
        return true;

        //return ownerData.IsHostile(other.ownerData);
    }

}
