using System.Collections.Generic;
using UnityEngine;

public class UnitFactory : MonoBehaviour
{
    public Unit Prototype;
    public Map Map;

    public List<ResourceCost> Costs;
    
    private Player owner;

    private void Start()
    {
        owner = GetComponentInParent<Player>();
        if (owner == null)
        {
            Debug.LogError("No Player found in hierarchy!");
        }
    }

    public void SpawnUnit(Cell cell)
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
            
            PlayerOwned ownerTag = newUnit.GetComponent<PlayerOwned>();
            if (ownerTag == null)
            {
                Debug.LogError("Unit needs to have a PlayerOwned component");
            }
            else
            {
                ownerTag.SetOwner(owner);
            }

        
            newUnit.transform.SetParent(cell.transform, false);
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