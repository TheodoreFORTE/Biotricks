/*
    This interface is intended to replace the OnEnable OnDisable pattern by allowing the gameObject : 

    - To "Vanish" by being completely transparent
    - To implement animators to appear on the scene
    - To be generic and usable for many gameObject


    This interface can let you manage collections of IVanishable to know which gameObject should appear or vanish on 
    the scene.

    The mock interface will just make the gameObject active or inactive based on the method.
    
*/

public interface IVanishable
{
    public void Vanish(); 
    public void Appear();

}
