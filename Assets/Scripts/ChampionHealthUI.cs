using UnityEngine;
using UnityEngine.UI;

public class ChampionHealthUI : MonoBehaviour
{
    public Image healthBar;    
    
    [SerializeField]
    private GameObject championController;

    private Champion linkedChampion;

    void Update()
    {   
        if(championController != null)
        {
            transform.position = championController.transform.position;//This object should follow the champion
        }
    }



    void UpdateHealthBar()
    {
        healthBar.fillAmount = linkedChampion.GetCurrentHealth() / linkedChampion.GetCurrentStat("Health");
    }

    public void LinkChampionData(GameObject _championController)
    {
        championController = _championController;
        linkedChampion = _championController.GetComponent<ChampionManager>().champion;
    }
}
