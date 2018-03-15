using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Tile tilePrefab;
    public Vector2 mapSize;

    //[Range(0,1)]
    //public float outlinePercent;


    private void Start()
    {
        GenerateMap();
    }
    
    
    public Tile getEmptyTile()
    {
        Tile[] allTiles = GetComponentsInChildren<Tile>();
        foreach (Tile tile in allTiles)
        {               
            if (tile.emptyTile)
                return tile;
        }
        return null;
    }
    
    public void GenerateMap()
    {
        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x / 2 + 0.5f + x, 0, -mapSize.y/2 + 0.5f + y);
                Tile newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right));
                newTile.transform.parent = gameObject.transform;
                //newTile.localScale =new Vector3(1,1,1/10) * (1-outlinePercent);
            }
        }
    }
}
