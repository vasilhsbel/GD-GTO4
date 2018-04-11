using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Unit : MonoBehaviour 
{
    private PlayerOwned owner;
    public List<Node> currentPath = new List<Node>();
    public Grid myGrid;

    public int tileX;
    public int tileY;
    int moveSpeed = 2;
    public int currX, currY, nextX, nextY;
    public Tile testTile;

    private void Update()
    {
        //Debug.Log("Is path null?");
        if (currentPath != null)
        {
            int currNode = 0;

            while (currNode < currentPath.Count - 1)
            {
                Tile tempTile = myGrid.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y);
                Tile tempTile2 = myGrid.TileCoordToWorldCoord(currentPath[currNode + 1].x, currentPath[currNode + 1].y);
                Vector3 start = tempTile.transform.position + new Vector3(0,0,-1);
                Vector3 end = tempTile2.transform.position + new Vector3(0, 0, -1);
                currX = currentPath[currNode].x;
                currY = currentPath[currNode].y;
                nextX = currentPath[currNode+1].x;
                nextY = currentPath[currNode+1].y;
                currNode++;
                //Debug.Log("Drawing?");
                Debug.DrawLine(start, end, Color.blue,2,false);
                //MoveNextTile();
            }
        }
        //Debug.Log("IT IS");
    }



    public void SetGrid(Grid newGrid)
    {

        myGrid = newGrid;
    }

    public void MoveNextTile()
    {
        Debug.Log("Supposed to move");
        float remainingMovement = moveSpeed;
        
        while (remainingMovement > 0)
        {
            Debug.Log("inside loop");
            if (currentPath == null)
                return;
            Debug.Log("inside loop4443");
            // Get cost from current tile to next tile
            remainingMovement--;
                //myGrid.CostToEnterTile(currentPath[0].x, currentPath[0].y, currentPath[1].x, currentPath[1].y);
            Debug.Log("inside loop55555");
            // Move us to the next tile in the sequence
            tileX = currentPath[1].x;
            Debug.Log("inside loop66666");
            tileY = currentPath[1].y;
            Debug.Log("inside loop33333");
            Tile tempTile = myGrid.TileCoordToWorldCoord(tileX, tileY);
            testTile = tempTile;
            Debug.Log("inside loop222");
            //transform.position = tempTile.transform.position;  // Update our unity world position
            //Ray ray = Camera.main.ScreenPointToRay(myGrid.TileCoordToWorldCoord(tileX, tileY));
            //RaycastHit hitInfo;
            //Tile hitTile = new Tile() ;
            //if (Physics.Raycast(ray, out hitInfo))
            //{
            //    hitTile = hitInfo.collider.GetComponentInParent<Tile>();
            //    testTile = hitInfo.collider.GetComponentInParent<Tile>();
            //}

            transform.parent = tempTile.transform;
            transform.position = tempTile.transform.position;
            // Remove the old "current" tile
            currentPath.RemoveAt(0);

            if (currentPath.Count == 1)
            {
                // We only have one tile left in the path, and that tile MUST be our ultimate
                // destination -- and we are standing on it!
                // So let's just clear our pathfinding info.
                currentPath = null;
            }
        }

    }

    public void Start()
    {       
    }

}
