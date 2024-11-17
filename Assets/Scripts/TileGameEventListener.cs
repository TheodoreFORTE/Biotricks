using UnityEngine;


public class TileGameEventListener : GenericGameEventListener<GameEventArgs<Vector3Int>>
{   

    public override void OnEventRaised(GameEventArgs<Vector3Int> argument) // is not possible
    {
        if(argument.target == gameObject)
        {
            response.Invoke(argument);
        }
        else
        {
            Debug.Log("This is not the right GameObject");
        }        
    }
}
