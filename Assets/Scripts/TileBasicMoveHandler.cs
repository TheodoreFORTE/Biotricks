
using UnityEngine;

public class TileBasicMoveHandler : MonoBehaviour, IDragDropHandler
{
    
    public bool CanBeDragged()
    {

        /*
        Technical-wise : 
            - The player is not being requested to do another input -> NI

        GameLogic-wise :

            - The champion has more Action Points that the cost of a basic move -> NI
            - The champion has not performed more basic move than it is allowed to -> NI
            - The champion has not a special status -> Not prioritary
            - It is the player's turn for this champion -> NI
        */

        return true;
    }



    public bool CanBeDroppedHere()
    {
        /*
            GameLogic Wise : Reading the position of the mouse 

            - The tile is in range (modulo obstacles like walls) -> Partially Implemented 
            - There isn't any champ in the tile -> Not implemented
            
        */

        return false;
    }


    public void OnRightDrop()
    {
        /*
            Move the Controller to the tile from the 

        */
    }

    public void OnWrongDrop()
    {
        /*
            By default, the gameObject return to its original position;


        */
        Debug.Log("Haha it's not implemented yet !");
    }



}
