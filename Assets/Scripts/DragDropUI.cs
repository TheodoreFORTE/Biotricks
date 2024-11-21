using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Linq;


public class DragDropUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private IDragDropHandler dragDropHandler;

    private Vector3 mousePositionOffset;
    private Vector3 originalLocalPosition;
    private Transform parentTransform;
    private bool isDragged = false;

    void Awake()
    {
        
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



    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private Vector3 GetMouseWorldPosition()
    {
        //Capture mouse position
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }



    public void OnBeginDrag(PointerEventData eventData)
    {
        if(dragDropHandler.CanBeDragged())
        {
            originalLocalPosition = transform.localPosition;
            canvasGroup.alpha = 0.6f; // Rendre l'objet semi-transparent pendant le drag
            canvasGroup.blocksRaycasts = false; // Empêcher les interactions pendant le drag
            isDragged = true;
            mousePositionOffset = transform.position - GetMouseWorldPosition();
        }        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(isDragged)
        {
            rectTransform.anchoredPosition += eventData.delta; // Déplacer l'objet
            Vector3 currentPosition = GetMouseWorldPosition() + mousePositionOffset;
            transform.position = new Vector3(currentPosition.x, currentPosition.y , originalLocalPosition.z);
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(dragDropHandler.CanBeDroppedHere())
        {
            dragDropHandler.OnRightDrop();
        }

        else
        {
            transform.localPosition = originalLocalPosition;
            dragDropHandler.OnWrongDrop();
        }

        canvasGroup.alpha = 1f; // Restaurer la transparence
        canvasGroup.blocksRaycasts = true; // Réactiver les interactions
    }
}
