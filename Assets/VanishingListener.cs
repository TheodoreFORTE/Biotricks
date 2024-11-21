using UnityEngine;

public class VanishingListener : MonoBehaviour , IVanishable
{
    
    [SerializeField]
    private Animator animatorController;

    private GameEvent desiredBehaviourOnAppearance;
    private GameEvent desiredBehaviourOnVanish;

    void Awake()    
    {
        animatorController = GetComponent<Animator>();
    }


    public void Vanish()
    {
        animatorController.SetTrigger("Vanish");
    }

    public void Appear()
    {        
        animatorController.SetTrigger("Appear");
    }

    public void SetVanishBehaviour(GameEvent behaviour)
    {
        desiredBehaviourOnVanish = behaviour;
    }

    public void SetAppearBehaviour(GameEvent behaviour)
    {
        desiredBehaviourOnAppearance = behaviour;
    }



    public void ApplyVanishBehaviour()
    {
        desiredBehaviourOnVanish?.Invoke();
    }

    public void ApplyAppearBehaviour()
    {
        desiredBehaviourOnAppearance?.Invoke();
    }

    





}
