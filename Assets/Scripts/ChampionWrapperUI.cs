using UnityEngine;
using UnityEngine.UI;

public class ChampionWrapperUI : MonoBehaviour
{
    private Champion champion;
    
    [SerializeField]
    private Image championProfile;

    private Sprite championSprite;

    [SerializeField]
    private ChampionEventContainer championSceneRegisterRequest;




    public void LoadChampionData(Champion _champion)
    {
        champion = _champion;
        championSprite = Resources.Load<Sprite>($"Icons/Champions/{champion.GetName()}");
    }

    public void UpdateUI()
    {
        championProfile.sprite = championSprite;
    }

    public void SendChampionData()
    {
        GameEventArgs<Champion> championRegisterArgs = new GameEventArgs<Champion>(champion, context: transform.position);
        championSceneRegisterRequest?.onEvent.Invoke(championRegisterArgs);
    }

    


}
