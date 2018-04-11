using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Grid : MonoBehaviour {

    public Transform hexPrefab;
    public Unit SelectedUnit;

    Node[,] graph;
    int[,] tiles;
    
    //List<Node> currentPath = new List<Node>();

    public MouseManager mm;

    public int gridWidth = 11; // These 2 must be uneven so that there is always a hex in the middle.
    public int gridHeight = 11;

    float hexWidth = 1.732f; //Width and Height can be seen in Blender.
    float hexHeight = 2.0f;
    public float gap = 0.0f; //Optional gap setting between hexagons.

    Vector3 startPos;
   

    private void Start()
    {
        addGap();
        CalcStartPos();
        GenerateMapData();
        GeneratePathfindingGraph();
        CreateGrid();        
    }

    void GenerateMapData()
    {
        Debug.Log("GenerateMapData");
        tiles = new int[gridWidth, gridHeight];
        int x, y;

        for (x = 0; x < gridWidth; x++)
        {
            for (y = 0; y < gridHeight; y++)
            {
                tiles[x, y] = 0;
            }
        }
    }
       

    void GeneratePathfindingGraph()
    {
        graph = new Node[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                graph[x, y] = new Node();
                graph[x, y].x = x;
                graph[x, y].y = y;
            }
        }

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                //if (x > 0)
                //{
                //    graph[x, y].neighbours.Add(graph[x - 1, y]);
                //    if (y > 0 && x<gridWidth-1)
                //        graph[x, y].neighbours.Add(graph[x + 1, y]);

                //}

                //if (x < gridWidth-1)
                //{          
                //        graph[x, y].neighbours.Add(graph[x + 1, y]);                    
                //}

                //if(y>0)
                //{
                //    graph[x, y].neighbours.Add(graph[x, y - 1]);
                //    if(x>0 && x % 2 == 0)
                //        graph[x, y].neighbours.Add(graph[x-1, y - 1]);
                //    if(x<gridWidth-1)
                //        graph[x, y].neighbours.Add(graph[x+1, y - 1]);
                //}

                //if (y < gridHeight - 1)
                //{
                //    graph[x, y].neighbours.Add(graph[x, y + 1]);
                //    if (x>0 && x % 2 != 0)
                //        graph[x, y].neighbours.Add(graph[x-1, y + 1]);
                //    if(x<gridWidth-1 && x%2!=0)
                //        graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
                //}

                // This is the 8-way connection version (allows diagonal movement)
                // Try left
                if (x > 0)
                {
                    graph[x, y].neighbours.Add(graph[x - 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x - 1, y - 1]);
                    if (y < gridHeight - 1)
                        graph[x, y].neighbours.Add(graph[x - 1, y + 1]);
                }

                // Try Right
                if (x < gridWidth - 1)
                {
                    graph[x, y].neighbours.Add(graph[x + 1, y]);
                    if (y > 0)
                        graph[x, y].neighbours.Add(graph[x + 1, y - 1]);
                    if (y < gridHeight - 1)
                        graph[x, y].neighbours.Add(graph[x + 1, y + 1]);
                }

                // Try straight up and down
                if (y > 0)
                    graph[x, y].neighbours.Add(graph[x, y - 1]);
                if (y < gridHeight - 1)
                    graph[x, y].neighbours.Add(graph[x, y + 1]);

                // This also works with 6-way hexes and n-way variable areas (like EU4)
            }
        }
    }

    
    public void GeneratePathTo(int x, int y)
    {
        //Debug.Log("Path is here?");
        SelectedUnit = mm.UnitCheck;
        SelectedUnit.currentPath = null;

        if (UnitCanEnterTile(x, y) == false)
        {
            // We probably clicked on a mountain or something, so just quit out.
            return;
        }

        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

        List<Node> unvisited = new List<Node>();

        Node source = graph[SelectedUnit.tileX, SelectedUnit.tileY];
        Node target = graph[x, y];

        dist[source] = 0;
        prev[source] = null;

        foreach (Node element in graph)
        {
            if (element != source)
            {
                dist[element] = Mathf.Infinity;
                prev[element] = null;
            }
            //Debug.Log("Adding to unvisited");
            unvisited.Add(element);
        }

        //v = element
        //u = tempNode
        while (unvisited.Count > 0)
        {
            //Debug.Log("inside unvisited loop");
            Node tempNode = null;

            foreach (Node possibleNode in unvisited)
            {
                if (tempNode == null || dist[possibleNode] < dist[tempNode])
                {
                    tempNode = possibleNode;
                    //Debug.Log("temp node set");
                }
            }

            if (tempNode == target)
            {
                break;
            }
            //Debug.Log("After temp node");
            unvisited.Remove(tempNode);

            foreach (Node element in tempNode.neighbours)
            {
                float alt = dist[tempNode] + tempNode.DistanceTo(element);
                if (alt < dist[element])
                {
                    dist[element] = alt;
                    prev[element] = tempNode;
                }
            }
        }

        //Debug.DrawLine(new Vector3(-4,0,-3), new Vector3(0, 0, 0), Color.red,20000,false);
        if (prev[target] == null)
        {
            return;
        }
        //Debug.Log("Before initialization");
        List<Node>currentPath = new List<Node>();

        Node curr = target;

        while (curr != null)
        {
            currentPath.Add(curr);
            curr = prev[curr];
        }

        currentPath.Reverse();

        SelectedUnit.currentPath = currentPath;
        if (SelectedUnit.currentPath == currentPath)
        {
            //Debug.Log("Works");

        }

    }

    public Tile TileCoordToWorldCoord(int x, int y)
    {
        //foreach (Tile element in transform)
        //{
        //    if (element.X == x && element.Y == y)
        //        return element.transform.position;
        //}
        foreach (Transform child in transform)
        {
            if (child.GetComponent<Tile>().X == x && child.GetComponent<Tile>().Y == y)
            {
                return child.GetComponent<Tile>();
            }
        }
        return null;
    }

    void addGap()
    {
        hexWidth += hexWidth * gap;
        hexHeight += hexHeight * gap;
    }

    void CalcStartPos()
    {
        float offset = 0;
        if (gridHeight / 2 % 2 != 0)
        {
            offset = hexWidth / 2;
        }

        float x = -hexWidth * (gridWidth / 2) - offset;
        float z = hexHeight * 0.75f * (gridHeight / 2);

        startPos = new Vector3(x, 0, z);
    }

    Vector3 CalcWorldPos(Vector3 gridPos)
    {
        float offset = 0;
        if (gridPos.y % 2 != 0)
        {
            offset = hexWidth / 2;
        }

        float x = startPos.x + gridPos.x * hexWidth + offset;
        float z = startPos.z - gridPos.y * hexHeight * 0.75f;

        return new Vector3(x, 0, z);
    }
    public TileType[] tileTypes;

    void CreateGrid()
    {
        Debug.Log("Generate Map");
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                TileType tt = tileTypes[tiles[x, y]];
                //Transform hex = Instantiate(hexPrefab) as Transform;
                Tile hex = (Tile)Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);
                Vector2 gridPos = new Vector2(x, y);
                hex.transform.position = CalcWorldPos(gridPos);
                hex.transform.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;
                hex.GetComponentInChildren<Tile>().setCoordinates(x, y);
                ClickableTile ct = hex.GetComponent<ClickableTile>();
                ct.tileX = x;
                ct.tileY = y;
                ct.map = this;
                ct.mm = mm;
            }
        }
    }

    public bool UnitCanEnterTile(int x, int y)
    {

        // We could test the unit's walk/hover/fly type against various
        // terrain flags here to see if they are allowed to enter the tile.

        return tileTypes[tiles[x, y]].isWalkable;
    }

    public float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY)
    {

        TileType tt = tileTypes[tiles[targetX, targetY]];

        if (UnitCanEnterTile(targetX, targetY) == false)
            return Mathf.Infinity;

        float cost = tt.movementCost;

        if (sourceX != targetX && sourceY != targetY)
        {
            // We are moving diagonally!  Fudge the cost for tie-breaking
            // Purely a cosmetic thing!
            cost += 0.001f;
        }

        return cost;

    }
}
