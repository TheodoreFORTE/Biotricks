
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;


public class FieldScanner : MonoBehaviour
{
    private Tilemap tilemap;

    [SerializeField]
    //List of scriptable objects defined;
    private List<SpawnTile> spawnTiles;

    //Spawner object per TileBase
    private Dictionary<TileBase , GameObject> spawnTileDictionary;   
    //Final data to use in the game
    private Dictionary<Vector3Int, TileData> tileDictionary;    
    
    //Tool for spawn-related gamelogic
    [SerializeField]
    private TileEventContainer spawnCommunicator;

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

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int cellPosition = new Vector3Int(x, y, 0);
                TileBase tile = tilemap.GetTile(cellPosition);

                if (tile != null)
                {
                    //Debug.Log($"Tuile #{tileCounter} à {cellPosition}: {tile.name}");
                    tileDict.Add(cellPosition, new TileData());
                    
                    if(spawnTileDictionary.ContainsKey(tile))
                    {

                        spawnPositions.Add(cellPosition);

                        

                        //Instantiate(spawnTileDictionary[tile], worldPosition, Quaternion.Euler(0,0,90));
                        tileDict[cellPosition].isSpawnTile = true;

                    }

                    
                }
            }
            
        }
      
        return tileDict;

    }

    public void SendSpawnPositions()
    {
        foreach(Vector3Int position in spawnPositions)
        {
            Debug.Log($"I should send the data of {position}");
            GameEventArgs<Vector3Int> spawnData = new GameEventArgs<Vector3Int>(position);
            spawnCommunicator?.onEvent.Invoke(spawnData);
        }
    }




    

    


}