using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Champion",menuName = "Biotricks/Champion")]
public class ChampionData : ScriptableObject
{
    
    public string championName;
    public ClassData championClass;
    public ChampionStats stats;

    


}
