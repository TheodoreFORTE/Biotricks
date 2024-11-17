using UnityEngine;
using System.Collections.Generic;


public class BasicSetupper : MonoBehaviour
{    
    private ChampionData[] championsData;
    private List<Champion> champions;

    [SerializeField]
    private GameObject championSelectorPrefab;
    
    [SerializeField]
    private int numberOfChamps;

    
    public void Awake()
    {
        championsData = Resources.LoadAll<ChampionData>("Champions/");
        champions = new List<Champion>();

        foreach(ChampionData championData in championsData)
        {
            Champion champion = new Champion(championData);
            champions.Add(champion);
        }
    }

    public void Start()
    {
        RandomChampionComp(numberOfChamps);
    }



    public void RandomChampionComp(int number)
    {
        if(number <= champions.Count)
        {
            for(int i=0; i < number; i++)
            {
                Champion randomPick = champions[Random.Range(0,champions.Count)];    
                Debug.Log(randomPick.GetName());

                champions.Remove(randomPick);                
                Instantiate(championSelectorPrefab, transform);  
                

            }
        }
    }

    
    

}
