using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnit : MonoBehaviour {

    // Use this for initialization
    public Grid myGrid;
    public Unit myUnit;

    public void spawnUnit()
    {
        Tile fetchedTile = myGrid.getEmptyTile();
        Vector3 tilePosition = new Vector3(fetchedTile.transform.position.x, fetchedTile.transform.position.y, fetchedTile.transform.position.z);
        
        if (fetchedTile.emptyTile)
        {
            Unit newUnit = Instantiate(myUnit, tilePosition, Quaternion.Euler(Vector3.right));
        }
    }

    void Start () {
        spawnUnit();

    }
	
	// Update is called once per frame
	void Update () {
        spawnUnit();
    }
}
