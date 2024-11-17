using System;
using System.Collections.Generic;
using System.Linq;

public class Champion
{

    private string championName;

    private Dictionary<string, int> baseStatValues;
    private Dictionary<string, int> maxStatValues;
    private Dictionary<string, int> currStatValues;


    private int health;

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

    



    




}
