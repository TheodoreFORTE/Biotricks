using UnityEngine;

public class DefaultDragDropHandler : IDragDropHandler
{
    public bool CanBeDragged()
    {
        Debug.Log("DefaultDragDropHandler is being used on this ! ");
        return true;
    }
    
    public bool CanBeDroppedHere()
    {
        return false;
    }

    public void OnWrongDrop()
    {
        Debug.Log("You're not allowed to move this object. You're using the DefaultDragDropHandler");
    }
    
}
