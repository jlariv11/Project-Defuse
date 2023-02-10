using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType2Script : MonoBehaviour
{
    //randomize this value (between 1 - 10)
    public int clicksToBreak = 8;

    //randomize clicks to win good (between 1 - clicksToBreak)
    //randomize clicks to win neutral (between 1 - win good)

    void OnMouseDown()
    {
        clicksToBreak -= 1; 
    }
}
