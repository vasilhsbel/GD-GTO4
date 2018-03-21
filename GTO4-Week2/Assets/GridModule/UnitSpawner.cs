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
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Cell cell = hit.collider.GetComponentInParent<Cell>();
                    if (cell != null)
                    {
                        Unit unitOnCell = cell.GetComponentInChildren<Unit>();
                        if (unitOnCell == null)
                        {
                            builder.SpawnUnit(cell);
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
