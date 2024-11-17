using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class FieldManager : MonoBehaviour
{

    [SerializeField]
    private Tilemap tilemap;

    
    
    private Dictionary<TileBase, bool> tileDictionary;



    


    private void Awake()
    {
        tileDictionary = new Dictionary<TileBase, bool>();

        
    }







}
