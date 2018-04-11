using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Grid Map;


    public List<ResourceCost> Costs;
    
    // Temporary until we figure out a better way to decide where to spawn.
    //public Vector2Int SpawnCoordinate;

    public void SpawnUnit(Tile tile)
    {

        bool canAfford = true;
        for (int i = 0; i < Costs.Count; i++)
        {
            if (!Costs[i].CanAfford())
            {
                canAfford = false;
            }
        }
        
        
        if (canAfford)
        {
            for (int i = 0; i < Costs.Count; i++)
            {
                Costs[i].Pay();
            }

            Unit newUnit = Instantiate(Prototype);
            

            PlayerOwned ownertag = newUnit.GetComponent<PlayerOwned>();
            if (ownertag == null)
            {
                Debug.LogError("Unit needs to have a player owned component");
            }
            Player owner = GetComponentInParent<Player>();
            ownertag.setOwner(owner);
            newUnit.transform.SetParent(tile.transform, false);
            //Debug.Log("SET GRID?");
            newUnit.SetGrid(Map);
            newUnit.tileX = tile.X;
            newUnit.tileY = tile.Y;
            Map.SelectedUnit = newUnit;


        }
        else
        {
            Debug.Log("Not enough resources!");
        }

    }

    [System.Serializable]
    public class ResourceCost
    {
        public Resource Resource;
        public int Cost;

        public bool CanAfford()
        {
            return Resource.CanAfford(Cost);
        }

        public void Pay()
        {
            Resource.RemoveAmount(Cost);
        }
        
    }
}