using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallSetupper : MonoBehaviour
{
    

    public Dictionary<TileBase, Dictionary<string,bool>> wallDataDictionary;

    private Tilemap tilemap;

    [SerializeField]
    public List<WallTile> wallTiles;

    [SerializeField]
    private Transform wallParentTransform;

    [SerializeField]
    public GameObject wallPrefab;

    public void Awake()
    {

        tilemap = GetComponent<Tilemap>();
        wallDataDictionary = new Dictionary<TileBase, Dictionary<string,bool>>();

        foreach(WallTile _wallTile in wallTiles)
        {
            Dictionary<string,bool> _wallDict = new Dictionary<string, bool>
            {
                { "L", _wallTile.hasLeftWall },
                { "R", _wallTile.hasRightWall },
                { "BR", _wallTile.hasBRightWall },
                { "BL", _wallTile.hasBLeftWall }
            };

            wallDataDictionary.Add(_wallTile.tilebase,_wallDict);
        }
        GenerateWalls();

    }

public void GenerateWalls()
{
    BoundsInt bounds = tilemap.cellBounds;

    float R = 130f;
    float W = Mathf.Sqrt(3) * R; // Width of the hexagon
    float H = 2 * R;             // Height of the hexagon


    for (int x = bounds.xMin; x < bounds.xMax; x++)
    {
        for (int y = bounds.yMin; y < bounds.yMax; y++)
        {
            Vector3Int cellPosition = new Vector3Int(x, y, 0);
            Vector3 worldPosition = tilemap.CellToWorld(cellPosition);
            TileBase tile = tilemap.GetTile(cellPosition);

            if (tile != null)
            {
                if (wallDataDictionary.ContainsKey(tile))
                {
                    // Radius and dimensions
                    

                    // Left wall (L)
                    if (wallDataDictionary[tile]["L"] == true)
                    {
                        Vector3 leftPosition = worldPosition + new Vector3((-W / 2)- 15, 0, 0);
                        Instantiate(wallPrefab, leftPosition, Quaternion.Euler(0, -1.5f, 90)).transform.SetParent(wallParentTransform);
                    }

                    // Right wall (R)
                    if (wallDataDictionary[tile]["R"] == true)
                    {
                        Vector3 rightPosition = worldPosition + new Vector3((W / 2)+15, 0, 0);
                        Instantiate(wallPrefab, rightPosition, Quaternion.Euler(0, -1.5f, 90)).transform.SetParent(wallParentTransform);
                    }

                    // Bottom-Right wall (BR)
                    if (wallDataDictionary[tile]["BR"] == true)
                    {
                        Vector3 bottomRightPosition = worldPosition + new Vector3(W / 4, -H / 2, 0);
                        Instantiate(wallPrefab, bottomRightPosition, Quaternion.Euler(0, -1.5f, 30)).transform.SetParent(wallParentTransform);
                    }

                    // Bottom-Left wall (BL)
                    if (wallDataDictionary[tile]["BL"] == true)
                    {
                        Vector3 bottomLeftPosition = worldPosition + new Vector3(-W / 4, -H / 2, 0);
                        Instantiate(wallPrefab, bottomLeftPosition, Quaternion.Euler(0, -1.5f, 150)).transform.SetParent(wallParentTransform);
                    }
                }
            }
        }
    }
}



}

