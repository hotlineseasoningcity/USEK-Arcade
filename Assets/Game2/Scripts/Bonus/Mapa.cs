using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapa : MonoBehaviour
{
    public Texture2D map;
    public GameObject Meteorite;
    public GameObject WalkWalk;
    public GameObject shipBase;

    public int width;
    public int height;

    GameObject[,] grid;
    public int[,] gridInt;

    void Awake()
    {
        width = map.width;
        height = map.height;
        grid = new GameObject[width, height];
        gridInt = new int[width, height];

        GenerateGridFromMap();
    }

    void GenerateGridFromMap()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color pixelColor = map.GetPixel(x, y);

                if (pixelColor == Color.red)
                {
                    grid[x, y] = Instantiate(shipBase, new Vector2(x, y), Quaternion.identity);
                    gridInt[x, y] = (int)GridType.shipbase;
                }
                else if (pixelColor == Color.white)
                {
                    grid[x, y] = Instantiate(WalkWalk, new Vector2(x, y), Quaternion.identity);
                    gridInt[x, y] = (int)GridType.walkable;
                }
                else if (pixelColor == Color.black)
                {
                    grid[x, y] = Instantiate(Meteorite, new Vector2(x, y), Quaternion.identity);
                    gridInt[x, y] = (int)GridType.notWalkable;
                }
            }
        }
    }
}
public enum GridType
{
    walkable,
    shipbase,
    notWalkable
}
