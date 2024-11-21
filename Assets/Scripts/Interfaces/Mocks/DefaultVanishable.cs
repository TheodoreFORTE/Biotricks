using UnityEngine;

public class DefaultVanishable : MonoBehaviour, IVanishable
{
    
    public void Vanish()
    {
        gameObject.SetActive(false);
        Debug.LogWarning("You're using the default implementation of IVanishable !");
    }

    public void Appear()
    {
        gameObject.SetActive(true);
        Debug.LogWarning("You're using the default implementation of IVanishable !");
    }
}
