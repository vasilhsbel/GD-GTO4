using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    public Unit hoveredObject;
    public Unit selectedObject;
    public Tile selectedTile;
    public SelectionIndicator mySelectedIndicator;
    public SelectionIndicator myHoveredIndicator;
    public Player currentPlayer;


    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Unit hitObject = hitInfo.collider.GetComponentInParent<Unit>();
            Tile hitTile = hitInfo.collider.GetComponentInParent<Tile>();
            SelectObject(hitObject);
            SelectTile(hitTile);
        }
        else
        {
            ClearSelection();
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(hoveredObject!=null)
            {
                selectedObject = hoveredObject;
                mySelectedIndicator.activateSelection();
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mySelectedIndicator.disableSelection();
        }
    }

    void SelectObject(Unit obj)
    {
        if (hoveredObject != null)
        {
            if (obj == hoveredObject)
            {
                myHoveredIndicator.activateSelection();
                return;
            }               

            ClearSelection();
        }
        hoveredObject = obj;
        
    }

    void SelectTile(Tile obj)
    {
        if (hoveredObject != null)
        {
            if (obj == selectedTile)
            {               
                return;
            }

            ClearSelection();
        }
        selectedTile = obj;

    }

    void ClearSelection()
    {
        if (hoveredObject == null)
        {            
            return;
        }

        if (selectedTile == null)
        {
            return;
        }

        myHoveredIndicator.disableSelection();
        selectedTile = null;
        hoveredObject = null;
    }
}
