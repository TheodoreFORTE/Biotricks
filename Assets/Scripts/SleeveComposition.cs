using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;


public class SleeveComposition
{
    Card[] sleeveLV1;
    Card[] sleeveLV2;
    Card[] sleeveLV3;

    Card trumpCard; 


    
    public SleeveComposition()
    {
        sleeveLV1 = new Card[4];
        sleeveLV2 = new Card[4];
        sleeveLV3 = new Card[4];

    }


    public bool IsComplete()    
    {
        return !sleeveLV1.Contains(null) && !sleeveLV2.Contains(null) && !sleeveLV3.Contains(null) & trumpCard !=null;
    }



    public Dictionary<Card, int> SetUpFullSleeve()
    {
        if(IsComplete())
        {       
        
            Dictionary<Card, int> cardInventory = new Dictionary<Card, int>();
        
            for(int i = 0; i < 4; i++)
            {
                {
                    cardInventory.Add(sleeveLV1[i],3);
                    cardInventory.Add(sleeveLV2[i],3);
                    cardInventory.Add(sleeveLV3[i],3);
                }
            }

            cardInventory.Add(trumpCard,1);

            return cardInventory;

        }

        else throw new UserInputException("Your champion's sleeve is not complete");

    }






}
