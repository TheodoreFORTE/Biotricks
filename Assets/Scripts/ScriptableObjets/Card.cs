using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Biotricks/Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string cardName;

    [SerializeField]
    private ClassData cardClass;


    [Range(0,10)]
    [SerializeField]
    private int manaCost;

    [Range(0,3)]
    [SerializeField]
    private int sleeveLevel;







}
