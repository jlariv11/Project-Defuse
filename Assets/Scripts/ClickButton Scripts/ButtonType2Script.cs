using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType2Script : MonoBehaviour
{
    public int clicksToBreak;
    public int goodResult;
    public int neutralResult;

    void Start()
    {
        clicksToBreak = Random.Range(3, 16);
        neutralResult = Random.Range(2, clicksToBreak);
        goodResult = Random.Range(1, neutralResult);
    }

    void OnMouseDown()
    {
        clicksToBreak -= 1;

        if (clicksToBreak == 0)
        {
            Debug.Log("Button Broke!");
        }
        else if (clicksToBreak == neutralResult)
        {
            Debug.Log("Neutral Result Reached");
        }
        else if (clicksToBreak == goodResult)
        {
            Debug.Log("Good Result Reached");
        }
        else
        {
            Debug.Log("Random Press");
        }
    }
}
