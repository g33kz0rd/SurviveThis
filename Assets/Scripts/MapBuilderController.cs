using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;

public class MapBuilderController : MonoBehaviour
{
    // Start is called before the first frame update
    public int x_offset = 0; // <- +>
    public int y_offset = 0; // v- +^
    public float magnification = 7.0f;

    public List<Tile> tiles = new List<Tile>();


    List<List<GameObject>> noise_grid = new List<List<GameObject>>();
    float totalPoints;

    private void Awake()
    {
        totalPoints = tiles.Sum(x => x.Density);
        GenerateMap();
    }

    void GenerateMap()
    {
        int map_width = 50;
        int map_height = 50;
        for (int x = 0; x < map_width; x++)
        {
            noise_grid.Add(new List<GameObject>());

            for (int y = 0; y < map_height; y++)
            {
                noise_grid[x].Add(GetTileAt(x, y));
            }
        }
    }

    GameObject GetTileAt(int x, int y)
    {
        float tile_id = GetIdUsingPerlin(x, y);

        Tile tile = tiles[0];

        foreach (Tile t in tiles)
        {
            tile_id -= t.Density;

            if (tile_id > 0)
                continue;

            tile = t;
            break;
        }

        return Instantiate(tile.GameObject, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
    }

    // Update is called once per frame
    float GetIdUsingPerlin(int x, int y)
    {
        float raw_perlin = Mathf.PerlinNoise(
            (x - x_offset) / magnification,
            (y - y_offset) / magnification
        );

        float clamp_perlin = Mathf.Clamp01(raw_perlin);
        float scaled_perlin = clamp_perlin * totalPoints;

        return scaled_perlin;
    }
}

[Serializable]
public struct Tile
{
    public GameObject GameObject;
    public float Density;
}