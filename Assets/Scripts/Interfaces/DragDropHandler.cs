using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface DragDropHandler
{
    
    public bool CanBeDragged();

    public bool CanBeDroppedHere();

    public virtual void OnWrongDrop()
    {
      // e.g : Notifying the user that he's done something incorrect (sound , UIText) ... 
    } 

    public virtual void OnRightDrop() 
    {
      // e.g Modifying the GameState appropriately , playing animations ... 
    }
}
