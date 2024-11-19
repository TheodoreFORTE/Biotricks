using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapLocator : MonoBehaviour
{
    // Static instance for singleton behavior
    private static TilemapLocator instance;


    private Tilemap tilemap;

    // Singleton instance getter
    public static TilemapLocator Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("TilemapLocator instance is not initialized!");
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Prevent duplicate instances
            return;
        }
        instance = this;
        tilemap = GetComponent<Tilemap>();
        
    }


    /// Converts a world position to a grid position.
    
    public Vector3Int WorldToGrid(Vector3 worldPosition)
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned!");
            return Vector3Int.zero;
        }
        return tilemap.WorldToCell(worldPosition);
    }

    /// Converts a grid position to a world position.

    public Vector3 GridToWorld(Vector3Int gridPosition)
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned!");
            return Vector3.zero;
        }
        return tilemap.CellToWorld(gridPosition);
    }


    /// Checks if a tile exists at the given grid position. 
    public bool HasTileAt(Vector3Int gridPosition)
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap is not assigned!");
            return false;
        }
        return tilemap.HasTile(gridPosition);
    }
}
