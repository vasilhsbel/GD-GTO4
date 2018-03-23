using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    public Transform hexPrefab;

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
        CreateGrid();
    }

    public float getXspeed()
    {
        return (hexWidth + gap);
    }

    public float getZspeed()
    {
        return (hexHeight + gap);
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

    void CreateGrid()
    {
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Transform hex = Instantiate(hexPrefab) as Transform;
                Vector2 gridPos = new Vector2(x, y);
                hex.position = CalcWorldPos(gridPos);
                hex.parent = this.transform;
                hex.name = "Hexagon" + x + "|" + y;
            }
        }
    }


}
