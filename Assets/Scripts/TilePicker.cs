using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilePicker : MonoBehaviour
{
    
  
    [SerializeField]
    private TileEventContainer tileEventContainer;
    private Tilemap tilemap;

    private bool isReadingAnInput = false;


    void Awake()
    {
        tilemap = GameObject.FindGameObjectWithTag("WalkableMap").GetComponent<Tilemap>();
        
    }

    void Update()
    {
        if(isReadingAnInput)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int gridPosition = tilemap.WorldToCell(mousePosition);

                if (tileEventContainer == null)
                {
                    Debug.LogError("tileEventContainer est null");
                    return;
                }

                if (tileEventContainer.onEvent == null)
                {
                    Debug.LogError("onEvent dans tileEventContainer est null");
                    return;
                }
                    
                // On doit savoir qui est le demandeur de la requête et créer un GameEventArgs approprié !
                GameEventArgs<Vector3Int> requestObject = new GameEventArgs<Vector3Int>(gameObject, gridPosition);

                tileEventContainer.onEvent.Invoke(requestObject);  
                isReadingAnInput = false;
            }
        }

        
    }

    public void IsReadingAnInput()
    {
        isReadingAnInput = true;
    }

}
