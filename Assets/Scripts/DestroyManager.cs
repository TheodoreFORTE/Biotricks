using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//The class that is responsible to make the gameObject, die, horribly :'(
public class DestroyManager : MonoBehaviour
{
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
   
   
}
