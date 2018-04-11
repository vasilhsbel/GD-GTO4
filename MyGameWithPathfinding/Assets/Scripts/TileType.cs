﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileType
{
    public string TileName;
    public Tile tileVisualPrefab;

    public bool isWalkable = true;
    public float movementCost = 1;
}
