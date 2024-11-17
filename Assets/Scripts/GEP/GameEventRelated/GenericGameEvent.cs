using UnityEngine;
using UnityEngine.Events;



public class GenericEventContainer<T> : ScriptableObject
{
    public UnityEvent<T> onEvent = new UnityEvent<T>();
}

public class GenericGameEvent<T> : MonoBehaviour
{
    public GenericEventContainer<T> eventContainer;

    public void Invoke(T argument)
    {
        eventContainer.onEvent.Invoke(argument);
    }

    public void Register(GenericGameEventListener<T> listener)
    {
        eventContainer.onEvent.AddListener(listener.OnEventRaised);
    }

    public void Deregister(GenericGameEventListener<T> listener)
    {
        eventContainer.onEvent.RemoveListener(listener.OnEventRaised);
    }
}

