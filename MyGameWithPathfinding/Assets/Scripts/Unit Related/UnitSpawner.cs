using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {

    public UnitFactory builder;

    private bool inSpawnMode;

    // Update is called once per frame
    void Update()
    {
        if (inSpawnMode)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Tile tile = hit.collider.GetComponentInParent<Tile>();
                    if (tile != null)
                    {
                        Unit unitOnCell = tile.GetComponentInChildren<Unit>();
                        if (unitOnCell == null)
                        {
                            builder.SpawnUnit(tile);
                            inSpawnMode = false;
                        }
                    }
                }
            }
        } 
	}

    public void EnterSpawnMode(UnitFactory factory)
    {
        builder = factory;
        inSpawnMode = true;
    }
}
