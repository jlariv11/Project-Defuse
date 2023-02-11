using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGameManager : MonoBehaviour
{
    public bool taskSuccess;
    public int minigameResult;

 
    public int determineResult(int minigameScore)
    {
        if (minigameScore == 999)
        {
            return minigameResult = 0;

        }
        else if (minigameScore == 6)
        {
            return minigameResult = 1;

        }
        else if (minigameScore > 8)
        {
            return minigameResult = 2;
        }
        else
        {
            return minigameResult = -1;
        }
    }

   
}
