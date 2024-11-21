using UnityEngine;
using UnityEngine.UI;

public class ChampionHealthUI : MonoBehaviour
{
    public Image healthBar;    
    
    [SerializeField]
    private GameObject championController;
    private Champion linkedChampion;



    void Awake()
    {
        GameObject mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        transform.SetParent(mainCanvas.transform);    
    }




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
        linkedChampion = _championController.GetComponent<ChampionWrapperScene>().champion;
    }
}
