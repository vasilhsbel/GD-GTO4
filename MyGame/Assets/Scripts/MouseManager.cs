using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour {

    public Tile hoveredTile;
    //public Unit selectedObject;
    public Tile selectedTile;
    public SelectionIndicator mySelectedIndicator;
    public SelectionIndicator myHoveredIndicator;
    public Player currentPlayer;
    public TurnManager myManager;
    public Unit UnitCheck;
    public Player checkPlayer;
    PlayerOwned temp;


    // Use this for initialization
    void Start ()
    {
        updatePlayer();

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Tile hitTile = hitInfo.collider.GetComponentInParent<Tile>();
            HoverTile(hitTile); //Set current tile as hovered tile.
            
        }
        else
        {
            //myHoveredIndicator.disableSelection();
            ClearSelection();
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(hoveredTile!=null)
            {
                UnitCheck = hoveredTile.GetComponentInChildren<Unit>();
                if (UnitCheck != null)
                {
                    temp = UnitCheck.GetComponentInChildren<PlayerOwned>();
                    checkPlayer = temp.owner;

                }


                if (UnitCheck==null || (checkPlayer == currentPlayer))
                {
                    selectedTile = hoveredTile;
                    SelectObject(selectedTile);
                    mySelectedIndicator.activateSelection();

                }
            }

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            selectedTile = null;
            mySelectedIndicator.disableSelection();
        }
    }

    public void updatePlayer()
    {
        currentPlayer = myManager.getPlayer();
    }

    void SelectObject(Tile obj)
    {
        if (hoveredTile != null)
        {
            if (obj == hoveredTile)
            {
                myHoveredIndicator.activateSelection();
                return;
            }               

            ClearSelection();
        }
        selectedTile = obj;
        
    }

    void HoverTile(Tile obj)
    {
        if (hoveredTile != null)
        {
            myHoveredIndicator.activateSelection();
            if (obj == selectedTile)
            {               
                return;
            }

            ClearSelection();
        }

        hoveredTile = obj;

    }

    void ClearSelection()
    {
        if (hoveredTile == null)
        {
            myHoveredIndicator.disableSelection();
            return;
        }

        if (selectedTile == null)
        {
            return;
        }
        
        hoveredTile = null;
    }
}
