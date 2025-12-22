using System;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject tile;

    List<TileDatum> tiles;
    List<GameObject> tile_game_objects;
    Vector3 last_tile_position;

    public void load_tiles(List<TileDatum> tiles)
    {
        this.tiles = tiles;
        last_tile_position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    public void create_tiles()
    {
        tile_game_objects = new List<GameObject>();
        for(int i = 0; i < tiles.Count; i++)
        {
            Vector3 next_tile_offset = GameController.movement_vectors[tiles[i].direction];

            Debug.Log($"tile {i} direction {tiles[i].direction} last_tile_position {last_tile_position} next tile offset {next_tile_offset}");

            Vector3 new_position = last_tile_position + next_tile_offset;
            last_tile_position = new_position;
            tile_game_objects.Add(Instantiate(tile, new_position, transform.rotation));
            Debug.Log($"Created tile at {new_position}");
        }
    }

    public void destroy_tile(int index)
    {
        Destroy(tile_game_objects[index]);
    }
}