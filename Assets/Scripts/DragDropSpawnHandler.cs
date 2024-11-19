using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Experimental.AI;
using Unity.VisualScripting;

public class DragDropSpawnHandler : MonoBehaviour, DragDropHandler
{

    
    // Through inspector
    [SerializeField]
    private GameEvent spawnPositionRequests;

    [SerializeField]
    private TileEventContainer moveRequest;




    // On runtime
    private Vector3 worldPosition;
    private Vector3Int gridPosition;


    //Instanciated on  Awake()

    private List<Vector3Int> spawnPositions;
    private Transform parentTransform;
    private GameObject mainCanvas;


    void Awake()
    {
        spawnPositions = new List<Vector3Int>();
        spawnPositionRequests?.Invoke();
        parentTransform = transform.parent.transform;
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");        
    }

    void Update()
    {
        /*
            Needs to check if all the champion Controller have been correctly affected to a Spawn Tile
        */
    }


    public void RegisterSpawnPosition(GameEventArgs<Vector3Int> spawnCommunication)
    {
        spawnPositions.Add(spawnCommunication.data);
        Debug.Log($"Spawn tile registered at {spawnCommunication.data}");
    }


    public bool CanBeDragged()
    {
        return true;
    }

    public bool CanBeDroppedHere()
    {
        /*           
            Check the tile where the image is being dropped. If it's a spawn point return true:            
        */
        worldPosition = transform.position;
        gridPosition = TilemapLocator.Instance.WorldToGrid(worldPosition);
        
        
        if(spawnPositions.Contains(gridPosition))
        {
            return true;
        }

        return false;
    }

    public void OnRightDrop()
    {    
        // Removing the gameObject from the Champion launcher 
        parentTransform.SetParent(mainCanvas.transform);     

        //Repositioning the draggable related to the controller
        transform.localPosition = new Vector3(0,0,0);

        //Creating a request
        GameEventArgs<Vector3Int> requestArgs = new GameEventArgs<Vector3Int>(transform.parent.gameObject, gridPosition);
             
        //Invoking the request
        moveRequest?.onEvent.Invoke(requestArgs);
        
        
        Debug.Log("Right drop !");
        
        /*            
            ToBeImplemented -> the management of a drop on tile with a different champion already in
            But right before, if there was already an image, put the image back to the Champion Launcher
        */        
    }

    public void OnWrongDrop()
    {
        /*  
            The element return where he was from by default
        */


        Debug.Log("Wrong drop using the DragDropSpawnHandler");
    }
  
}
