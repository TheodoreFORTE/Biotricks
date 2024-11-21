
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;


public class DragDrop : MonoBehaviour
{
    
    
    private Vector3 mousePositionOffset;
    private Vector3 originLocalPosition;
    

    private IDragDropHandler dragDropHandler;
    private Transform parentTransform;

    private bool uponDragging = false;


    public void Start() 
    {
        originLocalPosition = transform.localPosition;
        parentTransform = transform.parent.transform;

        IDragDropHandler[] handlers = GetComponents<IDragDropHandler>();


        if(handlers.Count() == 1)
        {
           dragDropHandler = handlers[0]; //best case scenario that should be frequent enough            
        }

        else 
        {
            Debug.LogWarning($"Number of DragDropHandlers on {name} : {handlers.Count()}. Taking into account a restrictive default one");
            dragDropHandler = new DefaultDragDropHandler();
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        //Capture mouse position
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    private void OnMouseDown()
    {
        if(dragDropHandler.CanBeDragged())
        {
            uponDragging = true;
            mousePositionOffset = transform.position - GetMouseWorldPosition();
            
        }
        
    }

    private void OnMouseDrag()
    {
        if(uponDragging)
        {
            Vector3 currentPosition = GetMouseWorldPosition() + mousePositionOffset;
            transform.position = new Vector3(currentPosition.x, currentPosition.y , originLocalPosition.z);
        }       
    }

    private void OnMouseUp()
    {
        if(dragDropHandler.CanBeDroppedHere()) // Moving the controller and doing some stuff
        {
            //parentTransform.position = new Vector3(transform.position.x, transform.position.y, 0);
            dragDropHandler.OnRightDrop();
        }

        else
        {            
            dragDropHandler.OnWrongDrop();
        }

        transform.localPosition = originLocalPosition;
        uponDragging = false;
    }
    
}
