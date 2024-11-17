
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class FieldScanner : MonoBehaviour
{
    private Tilemap tilemap;

    [SerializeField]
    private List<SpawnTile> spawnTiles;

    

    private Dictionary<TileBase , GameObject> spawnTileDictionary;


    private Dictionary<Vector3Int, TileData> tileDictionary;

    private List<Vector3Int> spawnPositions;


    public void Awake()
    {
        tilemap = GetComponent<Tilemap>();
        spawnPositions = new List<Vector3Int>();


        spawnTileDictionary = new Dictionary<TileBase, GameObject>();
        foreach(SpawnTile spawnTile in spawnTiles)
        {
            spawnTileDictionary.Add(spawnTile.tile,spawnTile.prefabToSpawn);
        }


        tileDictionary = ScanTilemap();

        



    }

    public Dictionary<Vector3Int, TileData> ScanTilemap()
    {
        BoundsInt bounds = tilemap.cellBounds;

        Dictionary<Vector3Int, TileData> tileDict = new Dictionary<Vector3Int, TileData>();

        int tileCounter = 0;

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                Vector3 worldPosition = tilemap.CellToWorld(cellPosition);
                TileBase tile = tilemap.GetTile(cellPosition);

                if (tile != null)
                {
                    //Debug.Log($"Tuile #{tileCounter} à {cellPosition}: {tile.name}");
                    tileDict.Add(cellPosition, new TileData());
                    
                    if(spawnTileDictionary.ContainsKey(tile))
                    {
                        Instantiate(spawnTileDictionary[tile], worldPosition, Quaternion.Euler(0,0,90));
                    }

                    tileCounter++;
                }
            }
            
        }
        //Debug.Log(tileCounter +" "+ gameObject.tag ); 
        return tileDict;

    }

    public List<Vector3Int> GetSpawnPositions()
    {
        return new List<Vector3Int>(spawnPositions);
    }


}