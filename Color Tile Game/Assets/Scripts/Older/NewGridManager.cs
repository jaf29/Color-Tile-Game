using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGridManager : MonoBehaviour
{
    public Sprite sprite;
    private float[,] Grid;
    private int Columns, Rows;

    // Start is called before the first frame update
    void Start()
    {
        Columns = 5;
        Rows = 5;
        Grid = new float[Columns, Rows];
        for (int i = 0; i < Columns; i ++)
        {
            for (int j = 0; j < Rows; j ++)
            {
                Grid[i, j] = 1;
                SpawnTile(i, j, Grid[i, j]);
            }
        }
    }

    private void SpawnTile(int x, int y, float value)
    {
        GameObject g = new GameObject("x: " + x + "y: " + y);
        g.transform.position = new Vector3(x - (Rows - 0.5f), y - (Columns - 0.5f));
        var s = g.AddComponent<SpriteRenderer>();
        s.sprite = sprite;
        s.color = new Color(value, value, value);
    }
}
//https://bitbucket.org/Sniffle6/2d-array-series/src/master/Youtube%20Series/Assets/Tutorials/2_Place%20Tile%20On%20Grid/GridManagerPlaceTiles.cs