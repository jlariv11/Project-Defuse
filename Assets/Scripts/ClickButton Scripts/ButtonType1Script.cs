using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType1Script : MonoBehaviour
{

    public int clicksToBreak; 
    public int goodResult;
    public int neutralResult;

    public ButtonGameManager buttonManager;

    public int buttonScore = 0;
    

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
    
    int determineButtonOutcome(int clicksToBreak)
    {
        if (clicksToBreak == 0)
        {
            Debug.Log("Button Broke!");
            buttonScore = 999;
        }
        else if (clicksToBreak == neutralResult)
        {
            Debug.Log("Neutral Result Reached");
            buttonScore = 1;
        }
        else if (clicksToBreak == goodResult)
        {
            Debug.Log("Good Result Reached");
            buttonScore = 2;
        }

        return buttonScore; 
    }

    public int getScore()
    {
        return buttonScore;
    }

}

