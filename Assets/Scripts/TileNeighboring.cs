using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileNeighboring : MonoBehaviour
{

    //Relative Coordinates of neighbors if the Y axis is even
    private List<Vector3Int> adjacentDirectionsForEvenY = new List<Vector3Int>
    {
        new Vector3Int(-1, 0, 0),// Left
        new Vector3Int( 1, 0, 0), // Right
        new Vector3Int(-1, -1, 0),//  Bottom-Left
        new Vector3Int( -1 , 1, 0), // Top-Left
        new Vector3Int( 0, 1, 0), // Top-Right
        new Vector3Int( 0, -1, 0), // Bottom-Right       
        
    };

    // Relative Coordinates if the Y axis is odd
    private List<Vector3Int> adjacentDirectionsForOddY = new List<Vector3Int>
    {
        new Vector3Int( -1, 0, 0), //Left
        new Vector3Int( 1, 0, 0), // Right
        new Vector3Int( 0, -1, 0), // Bottom-Left
        new Vector3Int( 0, 1, 0), //Top-Left
        new Vector3Int( 1, 1, 0), // Top-Right
        new Vector3Int( 1, -1, 0), // Bottom-Right

    };


    [SerializeField]
    private Tilemap tilemap;
    private Vector3Int currentCellPosition;

    void Start()
    {
    
    }

    public List<Vector3Int> GetPossibleDirections()
    {
        currentCellPosition = tilemap.WorldToCell(transform.position);


        List<Vector3Int> adjacentDirections = null;
        List<Vector3Int> neighbors = new List<Vector3Int>();

        if(currentCellPosition[1]%2 ==0)
        {
            adjacentDirections = adjacentDirectionsForEvenY;
        }

        else 
        {
            adjacentDirections = adjacentDirectionsForOddY;
        }

        foreach(Vector3Int direction in adjacentDirections)
        {
        
                Vector3Int locationToTest= currentCellPosition + direction;

                TileBase tileToTest = tilemap.GetTile(locationToTest);

                if(tileToTest != null)
                {
                    neighbors.Add(locationToTest);
                    //Debug.Log(locationToTest + "is a viable direction"); 
                }

        }

        return neighbors;        
    }

}
