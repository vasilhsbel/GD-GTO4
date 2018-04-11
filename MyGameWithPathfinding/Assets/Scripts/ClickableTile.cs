using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableTile : MonoBehaviour {

    public int tileX;
    public int tileY;
    public Grid map;
    public MouseManager mm;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (map.SelectedUnit != null)
            {
                map.GeneratePathTo(mm.selectedTile.X, mm.selectedTile.Y);
                //Debug.Log("Click!");
            }
        }
    }

    //void OnMouseUp()
    //{
    //    Debug.Log("Click!???????????");
    //    if(map.SelectedUnit!=null)
    //    {
    //        map.GeneratePathTo(mm.hoveredTile.X, mm.hoveredTile.Y);
    //        Debug.Log("Click!");
    //    }
    //}
}
