using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu(fileName= "New WallTile", menuName = "Biotricks/ScriptableTiles/WallTile")]
public class WallTile : ScriptableObject
{
    
    public TileBase tilebase;

    
    public bool hasLeftWall;    
    public bool hasRightWall;    
    public bool hasBLeftWall;
    public bool hasBRightWall;

}
