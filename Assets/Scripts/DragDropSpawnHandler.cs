using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropSpawnHandler : MonoBehaviour, DragDropHandler
{

    public bool CanBeDragged()
    {
        /*
            Unless there is a different input required, the game will always let the player drag the champions
       
        */




        return true;
    }

    public bool CanBeDroppedHere()
    {
        /*
            Check the tile where the image is being dropped. If it's a spawn point : 
            
        */



        return false;
    }

    public void OnRightDrop()
    {
        /*
            Set its parent to the spawn point that will be created.
            But right before, if there was already an image, put the image back to the Champion Launcher
        */



        Debug.Log("Right drop !");
    }

    public void OnWrongDrop()
    {
        /*  
            The element return where he was from
        */


        Debug.Log("Wrong drop using the DragDropSpawnHandler");
    }
  
}
