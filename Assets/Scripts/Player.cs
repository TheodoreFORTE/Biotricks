using System.Collections.Generic;

public class Player
{
    public static int playerNumber = 0;

    private string userName;
    private List<TeamComposition> playerComps;

    public Player()
    {
        userName = "Player_"+ playerNumber.ToString();
        playerNumber++;

        playerComps = new List<TeamComposition>();
    }



}
