using UnityEngine;
using UnityEngine.Events;


public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameEvent;
    [SerializeField]
    private UnityEvent unityEvent;

    void Awake() => gameEvent.Register(gameEventListener:this);

    void OnDestroy()=> gameEvent.Deregister(gameEventListener:this);

    public void RaiseEvent()
    {
         unityEvent.Invoke();
    }

  
    
}

