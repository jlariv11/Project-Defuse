using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonGameManager : MonoBehaviour
{
    public bool taskFailed = false;

    public int taskResult = 0;

    public int taskCount = 0;

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
        int minigameCount = calculateTaskCount();

        if (6 <= minigameCount && minigameCount <= 8)
        {
            Debug.Log("Task Complete, Neutral Result");
            taskResult = 1;
        } else if (minigameCount > 8)
        {
            Debug.Log("Task Complete, Good Result");
            taskResult = 2;
        } else
        {
            Debug.Log("Task Failed");
        }
    }
   
}
