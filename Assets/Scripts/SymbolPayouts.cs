using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Symnol", menuName = "Symnbol Payout")]
public class SymbolPayouts : ScriptableObject
{
    public int id;
    public string SymbolName;
    [HideInInspector]
    public int matchCount;
    [Header("PayOut per number of matches")]
    public int[] PayOut_per_Matches = new int [5];
    public int oneMatch;
    public int twoMatches;
    public int threeMatches;
    public int fourMatches;
    public int fiveMatches;

    float payout;

    public void ReleasePayout()
    {
        if (matchCount == 1)
            payout = oneMatch;
        else if(matchCount == 2)
            payout = twoMatches;
        else if (matchCount == 3)
            payout = threeMatches;
        else if (matchCount == 4)
            payout = fourMatches;
        else if (matchCount == 5)
            payout = fiveMatches;

    }
}
