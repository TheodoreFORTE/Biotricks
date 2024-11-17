using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Game Event", menuName = "Game Event", order = 52)] 
public class GameEvent : ScriptableObject
{
    private HashSet<GameEventListener> listeners = new HashSet<GameEventListener>();

    public void Invoke()
    {
        foreach(var eventListener in listeners)
        {
                             
            eventListener.RaiseEvent();
            
        }
    }

    
    public void Register(GameEventListener gameEventListener) 
    {
        listeners.Add(gameEventListener);
    }

    public void Deregister(GameEventListener gameEventListener)    
    {
        listeners.Remove(gameEventListener);
    }
}


