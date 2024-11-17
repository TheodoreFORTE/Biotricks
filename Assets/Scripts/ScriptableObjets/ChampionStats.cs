using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.UIElements.Experimental;


[CreateAssetMenu(fileName = "NewCharacterStats", menuName = "Biotricks/CharacterStats")]
public class ChampionStats : ScriptableObject
{
    [SerializeField]
    private List<Stat> stats;


    public Dictionary <string, int> ExportToBaseStatDictionary()
    {
        Dictionary<string,int>  finalData = new Dictionary<string, int>();

        foreach(Stat stat in stats)
        {
            finalData.Add(stat.name,stat.baseValue);
        }

        return finalData;
    }

    public Dictionary<string,int> ExportToMaxStatDictionary()
    {
        Dictionary<string,int>  finalData = new Dictionary<string, int>();

        foreach(Stat stat in stats)
        {
            finalData.Add(stat.name,stat.maxValue);
        }

        return finalData;
    }




}
