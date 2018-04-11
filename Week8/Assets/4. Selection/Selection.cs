using UnityEngine;

public class Selection : MonoBehaviour
{
    public enum SelectionMode
    {
        Normal = 0,
        GivingOrder = 1,
        PlacingUnit = 2,
    }
    
    public SelectionMode CurrentMode;
    public SelectableUnit CurrentSelection;
    public SelectableCell HoverCell;
    public UnitFactory CurrentBuilder;

    public GameObject SelectionCursorPrefab;
    private GameObject SelectionCursor;

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) { ClearSelection(); }
        
        // Handle Selection with left click
        if (CurrentMode == SelectionMode.Normal || CurrentMode == SelectionMode.GivingOrder)
        {
            // First: Left mouse button to select a target unit
            if (Input.GetMouseButtonDown(0)) // Left mouse button
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Debug.DrawRay(ray.origin, ray.direction * float.MaxValue, Color.cyan, 10f); // Debug our ray!

                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    SelectableUnit leftClickedObj = hitInfo.collider.GetComponentInParent<SelectableUnit>();
                    if (leftClickedObj != null)
                    {
                        ClearSelection(); // Deselect previous object

                        if (leftClickedObj.CanBeSelected())
                        {
                            SelectUnit(leftClickedObj);
                        }
                        else
                        {
                            Debug.Log("Unit not selectable by you!");
                        }
                    }
                    else
                    {
                        Debug.Log("Clicked object not a selectable unit!");
                    }
                }
            }
        }

        if (CurrentMode == SelectionMode.GivingOrder)
        {
            // Right mouse button to give a target to our current selection
            if (Input.GetMouseButtonDown(1)) // Right mouse button
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    Selectable rightClickedObj = hitInfo.collider.GetComponentInParent<Selectable>();
                    if (rightClickedObj != null)
                    {
                        CurrentSelection.GiveTarget(rightClickedObj);
                        ClearSelection();
                    }
                }
            }
        }

        if (CurrentMode == SelectionMode.PlacingUnit)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo))
            {
                SelectableCell newHoverCell = hitInfo.collider.GetComponentInParent<SelectableCell>();
                if (HoverCell != newHoverCell)
                {
                    if (HoverCell != null)
                    {
                        HoverCell.OnDeselect();
                    }
                    HoverCell = newHoverCell; // Can also be null!
                    if (HoverCell != null)
                    {
                        HoverCell.OnSelect();
                    }
                }
            }
            else // Moused over nothing
            {
                if (HoverCell != null)
                {
                    HoverCell.OnDeselect();
                    HoverCell = null;
                }
            }

            if (Input.GetMouseButton(0)) // Place with left mouse button
            {
                if (HoverCell != null)
                {
                    CurrentBuilder.SpawnUnit(HoverCell.GetCell());
                    ClearSelection();
                }
            }

            if (Input.GetMouseButton(1)) // cancel with right
            {
                ClearSelection();
            }
        }
    }

    public void GoToUnitPlacementMode(UnitFactory factory)
    {
        CurrentBuilder = factory;
        CurrentMode = SelectionMode.PlacingUnit;
    }

    public void SelectUnit(SelectableUnit unit)
    {
        CurrentSelection = unit;
        CurrentSelection.OnSelect();
        CurrentMode = SelectionMode.GivingOrder;

        if (SelectionCursor == null)
            SelectionCursor = GameObject.Instantiate(SelectionCursorPrefab);
                            
        SelectionCursor.transform.position = CurrentSelection.transform.position;
        SelectionCursor.SetActive(true);
    }
    
    public void ClearSelection()
    {
        if (CurrentSelection != null)
        {
            CurrentSelection.OnDeselect();
            CurrentSelection = null;
        }
        if (SelectionCursor != null)
            SelectionCursor.SetActive(false);
        
        CurrentBuilder = null;
        if (HoverCell != null)
        {
            HoverCell.OnDeselect();
            HoverCell = null;
        }

        CurrentMode = SelectionMode.Normal;
    }


    private void OnDisable()
    {
        ClearSelection();
    }
}
