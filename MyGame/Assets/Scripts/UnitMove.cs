﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour {

    public MouseManager mm;
    public Tile hitTile;
    public Unit selectedUnit;
    public Tile selectedTile;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mm.selectedTile != null)
        {
            selectedTile = mm.selectedTile;
            selectedUnit = mm.selectedTile.GetComponentInChildren<Unit>();


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                hitTile = hitInfo.collider.GetComponentInParent<Tile>();
            }
            if (hitTile != null)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    //MoveUnitTo();
                    if (selectedTile != null)
                    {
                        selectedUnit.transform.parent = hitTile.transform;
                        selectedUnit.transform.position = hitTile.transform.position;

                    }
                    mm.selectedTile = hitTile;

                }
            }
        }
    }

    public void MoveUnitTo()
    {
        selectedUnit = mm.selectedTile.GetComponentInParent<Unit>();
        selectedUnit.transform.parent = hitTile.transform;
        selectedUnit.transform.position = hitTile.transform.position;
    }
}
