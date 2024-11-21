using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChampionWrapperUI : MonoBehaviour
{
    public Champion champion;
    
    [SerializeField]
    private Image championProfile;    
    public Sprite championSprite;





    public void LoadChampionData(Champion _champion)
    {
        champion = _champion;
        championSprite = Resources.Load<Sprite>($"Icons/Champions/{champion.GetName()}");
        UpdateUI();
    }

    public void UpdateUI()
    {
        championProfile.sprite = championSprite;
    }



    
    


}
