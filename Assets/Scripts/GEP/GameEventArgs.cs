using UnityEngine;

public class GameEventArgs<T>
{
    public GameObject target; //Concerned GameObject
    public T data;
    public object context;

    public GameEventArgs(GameObject target, T data, object context = null)
    {
        this.target = target;
        this.data = data;
        this.context = context;
    }

    public GameEventArgs(T data, object context = null)
    {
        //this is an universal GameEventArgs
        this.target = null;
        this.data = data;
        this.context = context;

    }
}
