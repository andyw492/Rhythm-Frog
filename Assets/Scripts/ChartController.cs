using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.IO;

public class TileDatum
{
    public string direction;
    public float beats;
}

public class ChartController : MonoBehaviour
{
    public const string UP = "u";
    public const string DOWN = "d";
    public const string LEFT = "l";
    public const string RIGHT = "r";
    public const int grid_spacing = 16;

    public static Dictionary<string, Vector3> movement_vectors = new Dictionary<string, Vector3>
    {
        {UP, Vector3.up * grid_spacing},
        {DOWN, Vector3.down * grid_spacing},
        {LEFT, Vector3.left * grid_spacing},
        {RIGHT, Vector3.right * grid_spacing}
    };

    public CameraController camera_controller;
    public PlayerController player_controller;
    public TileController tile_controller;

    Dictionary<string, UnityEngine.InputSystem.Controls.KeyControl> keybinds;
    List<TileDatum> tiles;
    int current_tile_ptr = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        load_tiles("tutorial");
        load_keybinds();
        tile_controller.load_tiles(tiles);
        tile_controller.create_tiles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.anyKey.wasPressedThisFrame)
        {
            handle_input();
        }
    }

    private void handle_input()
    {
        string current_tile_direction = tiles[current_tile_ptr].direction;

        string input_direction = null;
        foreach (KeyValuePair<string, UnityEngine.InputSystem.Controls.KeyControl> kvp in keybinds)
        {
            string direction = kvp.Key;
            UnityEngine.InputSystem.Controls.KeyControl key_code = kvp.Value;
            if (key_code.wasPressedThisFrame)
            {
                input_direction = direction;
                Debug.Log($"Detected {key_code} press");
                break;
            }
        }
        Debug.Log($"input direction {input_direction} current_tile_direction {current_tile_direction} equal {input_direction == current_tile_direction}");
        if (input_direction != current_tile_direction)
        {
            return;
        }

        Vector3 movement = movement_vectors[input_direction];
        player_controller.move_player(movement);
        //camera_controller.move_camera(movement);
        tile_controller.destroy_tile(current_tile_ptr);

        current_tile_ptr += 1;
    }

    private void load_tiles(string file_name)
    {
        tiles = new List<TileDatum>();
        string file_path = $"{Application.streamingAssetsPath}/{file_name}.csv";
        foreach (string line in File.ReadLines(file_path))
        {
            string[] parts = line.Split(",");
            TileDatum new_tile = new TileDatum();
            new_tile.direction = parts[0];
            new_tile.beats = float.Parse(parts[1]);
            tiles.Add(new_tile);
        }
    }

    private void load_keybinds()
    {
        keybinds = new Dictionary<string, UnityEngine.InputSystem.Controls.KeyControl>();
        keybinds[UP] = Keyboard.current.upArrowKey;
        keybinds[DOWN] = Keyboard.current.downArrowKey;
        keybinds[LEFT] = Keyboard.current.leftArrowKey;
        keybinds[RIGHT] = Keyboard.current.rightArrowKey;
    }
}
