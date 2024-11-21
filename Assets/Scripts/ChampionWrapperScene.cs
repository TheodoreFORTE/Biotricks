using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChampionWrapperScene : MonoBehaviour
{
    public Champion champion;

    [SerializeField]
    private GameObject championSprite;

    [SerializeField]
    private ChampionEventContainer championRegisterRequest;


    public void LoadChampionData(ChampionWrapperUI _championUI)
    {
        champion = _championUI.champion;
        Debug.Log(_championUI.championSprite);
        championSprite.GetComponent<SpriteRenderer>().sprite = _championUI.championSprite;
        championRegisterRequest?.onEvent.Invoke(new GameEventArgs<Champion>(_championUI.champion));




    }





}
