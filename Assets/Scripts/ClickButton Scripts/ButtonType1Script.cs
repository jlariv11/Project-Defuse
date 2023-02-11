using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Random;

public class ButtonType1Script : MonoBehaviour
{

    public int clicksToBreak; 
    public int goodResult;
    public int neutralResult;

    public ButtonGameManager buttonManager;

    public int minigameScore = 0;
    public bool gameFailed = false;
    public int minigameResult;

    void Start()
    {
        clicksToBreak = Random.Range(3, 11);
        neutralResult = Random.Range(2, clicksToBreak);
        goodResult = Random.Range(1, neutralResult);
    }

    void OnMouseDown()
    {
        clicksToBreak -= 1;

        determineButtonOutcome(clicksToBreak);
        
    }

    public int determineButtonOutcome(int clicksToBreak)
    {
        if (clicksToBreak == 0)
        {
            Debug.Log("Button Broke!");
            gameFailed = true;
            minigameScore = 999;
        }
        else if (clicksToBreak == neutralResult)
        {
            Debug.Log("Neutral Result Reached");
            minigameScore += 1;
        }
        else if (clicksToBreak == goodResult)
        {
            Debug.Log("Good Result Reached");
            minigameScore += 2;
        }

        return minigameScore; 
    }

    public int determineResult(int minigameScore)
    {
        if (minigameScore == 999)
        {
            return minigameResult = 0;

        }
        else if (minigameScore == 2)
        {
            return minigameResult = 1;

        }
        else if (minigameScore == 3)
        {
            return minigameResult = 2;
        }
        else
        {
            return minigameResult = -1;
        }
    }

}

