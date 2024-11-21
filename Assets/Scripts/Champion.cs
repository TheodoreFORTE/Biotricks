using System;
using System.Collections.Generic;
using System.Linq;

public class Champion : IComparable<Champion>
{

    private string championName;

    private Dictionary<string, int> baseStatValues;
    private Dictionary<string, int> maxStatValues;
    private Dictionary<string, int> currStatValues;


    private int health;
    private int level;
    private string championClass;
    private Ability ability;
    public SleeveComposition sleeveComposition;



    public Champion(ChampionData championData)
    {
        championName = championData.championName;
        baseStatValues = championData.stats.ExportToBaseStatDictionary();
        maxStatValues = championData.stats.ExportToMaxStatDictionary();
        sleeveComposition = new SleeveComposition(); 
        championClass = championData.championClass.label;
        level = 1;
    }

    public int GetCurrentStat(string name)
    {
        if(currStatValues.ContainsKey(name))
        {
            return currStatValues[name];
        }
        else throw new SystemException($"The stat {name} of {championName} doesn't exist");
    }

    public void InitializeLife()
    {
        this.health = currStatValues["Health"];
    }

    public int GetCurrentHealth()
    {
        return this.health;
    }

    public string GetName()
    {
        return new string(championName);
    }

    public int GetLevel()
    {
        return level;
    }

    public int CompareTo(Champion champion)
    {
        if(champion == null) return 1;


        //First criteria : is the enemy is quickier ?
        int diff = GetCurrentStat("Speed") - champion.GetCurrentStat("Speed");

        if(diff != 0)
        {
            return diff;
        }


        else
        {
        
        //Second criteria : is the enemy has more level than you
            diff = GetLevel() - champion.GetLevel();

            if(diff != 0)
            {
                return diff;
            }

        //Last criteria : percentage of HP 
            return (GetCurrentHealth() / champion.GetCurrentStat("Health"))*100
            - (champion.GetCurrentHealth()/champion.GetCurrentStat("Health"))*100;
        }
    }
    
}
