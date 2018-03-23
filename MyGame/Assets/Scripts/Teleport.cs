using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    public MouseManager mm;
    public Tile hitTile;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (mm.selectedObject != null)
        {
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
                    Debug.Log("I AM HERE");
                    mm.selectedObject.transform.parent = hitTile.transform;
                    mm.selectedObject.transform.position = hitTile.transform.position;
                }
            }
        }
	}
}
