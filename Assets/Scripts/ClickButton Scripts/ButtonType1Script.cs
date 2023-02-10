using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType1Script : MonoBehaviour
{

    public int clicksToBreak = 5; 

    void OnMouseDown() 
    {
        clicksToBreak -= 1;
    }


}
