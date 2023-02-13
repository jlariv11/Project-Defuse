using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameManager : MonoBehaviour
{
    public bool taskFailed = false;

    public int taskCount = 0;
    //public int minigameResult;
    public Transform buttons;
    public ButtonType1Script[] buttonScripts;

    void Start()
    {
        buttonScripts = new ButtonType1Script[buttons.childCount];
        for (int i = 0; i < buttons.childCount; i++)
        {
            buttonScripts[i] = buttons.GetChild(i).GetComponent<ButtonType1Script>();
        }
    }
 
    void Update()
    {
        for (int i = 0; i < buttons.childCount; i++)
        {
            //int buttonResult = buttonScripts[i].getScore();
            if(buttonScripts[i].getScore() == 999)
            {
                taskFailed = true;
            } 
        }
    }

    public int calculateTaskCount()
    {
        for (int i = 0; i < buttons.childCount; i++)
        {
            int buttonResult = buttonScripts[i].getScore();
            if (buttonResult == 1 || buttonResult == 2)
            {
                taskCount += buttonResult;
            }
        }
        return taskCount;
    }

    public void validate()
    {
        calculateTaskCount();
    }



   
}
