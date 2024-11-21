using UnityEngine;


/*
This class is using the IVanishable generic class to handle the state of the board
based on the player input.

I would love to make this class generic

*/




public class VanishManager : MonoBehaviour
{
    
    private IVanishable stateManager;
    private bool canBeRequested = true;
    private string state = "Disabled";

    void Awake()
    {        
        stateManager = GetComponent<IVanishable>();

        if(stateManager == null)
        {
            Debug.LogWarning("No IVanishable component used on this! Using the default one");
            gameObject.AddComponent<DefaultVanishable>();
            stateManager = GetComponent<IVanishable>();

        }






    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(canBeRequested)
            {
                if(state == "Disabled")
                {
                    stateManager.Appear();
                    state = "Enabled";
                }

                else
                {
                    stateManager.Vanish();
                    state = "Disabled";
                }                
            }
        }
    }

    public void SetRequestTrigger(bool value)
    {
        canBeRequested = value;
    }

    









}
