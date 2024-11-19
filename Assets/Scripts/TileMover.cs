using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMover : MonoBehaviour
{
    
    private Tilemap tilemap;
    private GameObject playerController;
    private TileNeighboring tileNeighboring;
    private bool isRequestingToMove;

    void Awake()
    {
        //tilemap = GameObject.FindGameObjectWithTag("WalkableMap").GetComponent<Tilemap>();
        //playerController = transform.parent.gameObject;
        //tileNeighboring = GetComponent<TileNeighboring>();
        //isRequestingToMove= false;
    }

    public void RequestingToMove()
    {
        isRequestingToMove = true;
    }

    // Must be the method call by our TileEventContainer
    public void MoveToTile(GameEventArgs<Vector3Int> gameEventArgs)
    {

        if(isRequestingToMove)
        {
            if(tileNeighboring.GetPossibleDirections().Contains(gameEventArgs.data))
            {
                Vector3 worldPosition = tilemap.CellToWorld(gameEventArgs.data);
                playerController.transform.position = worldPosition;
            }
            else
            {
                Debug.Log("You cannot move to this tile");
            }
            isRequestingToMove=false;
        }
        
    }

    public void TeleportUIToTile(GameEventArgs<Vector3Int> gameEventArgs)
    {
        GameObject objectToTeleport = gameEventArgs.target;
        Vector3Int cellPosition = gameEventArgs.data;

        objectToTeleport.transform.position = TilemapLocator.Instance.GridToWorld(cellPosition);

        Debug.Log("I have teleported the UI aspect of the player !");

    }

}
