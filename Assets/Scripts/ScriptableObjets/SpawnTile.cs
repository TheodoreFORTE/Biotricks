using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName= "New SpawnTile", menuName = "Biotricks/ScriptableTiles/SpawnTile")]
public class SpawnTile : ScriptableObject
{
    
    public TileBase tile;
    public bool isPlayerSide;

    public GameObject prefabToSpawn;    



}
