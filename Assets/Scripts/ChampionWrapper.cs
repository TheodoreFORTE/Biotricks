using UnityEngine;
using UnityEngine.UI;

public class ChampionWrapper : MonoBehaviour
{
    private Champion champion;
    
    [SerializeField]
    private Image championProfile;
    private Sprite championSprite;

    public void LoadChampionData(Champion _champion)
    {
        champion = _champion;
        championSprite = Resources.Load<Sprite>($"Icons/Champions/{champion.GetName()}");
    }

    public void UpdateUI()
    {
        championProfile.sprite = championSprite;
    }


}
