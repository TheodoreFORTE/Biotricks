using UnityEngine;

public class CanvasFollow : MonoBehaviour
{
    public Transform target;  // Le personnage que le Canvas doit suivre

    void Update()
    {
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
