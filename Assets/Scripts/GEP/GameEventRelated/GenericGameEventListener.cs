using UnityEngine;
using UnityEngine.Events;



public class GenericGameEventListener<T> : MonoBehaviour
{
    public GenericEventContainer<T> eventContainer;
    public UnityEvent<T> response;

    private void OnEnable()
    {
        eventContainer.onEvent.AddListener(OnEventRaised);
    }

    private void OnDisable()
    {
        eventContainer.onEvent.RemoveListener(OnEventRaised);
    }

    public virtual void OnEventRaised(T argument)
    {
        response.Invoke(argument);
    }
}

