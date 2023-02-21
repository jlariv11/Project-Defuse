using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public static class GameManager
{
    public static string CONNECTING_WIRES = "ConnectingWires";
    public static string SIMON_SAYS = "SimonSays";
    public static string LEVERS = "Levers";
    public static string CODE = "Code";
    public static string MAZE = "Maze";
    public static string CLICK_BUTTON = "ClickButton";
    public static string INSTRUCTIONS = "InstructionScene";
    public static string MENU = "MenuScene";

    public static Color[] secretSimonSaysPattern { get; set; }
    public static int[] secretCode { get; set; }
    public static Color[] secretLeverPattern { get; set; }

    public static void createSecretOrder(int secretOrderLength, Color[] colors)
    {
        Color[] secretOrder = new Color[secretOrderLength];
        for (int i = 0; i < secretOrderLength; i++)
        {
            int index = Random.Range(0, colors.Length);
            secretOrder[i] = colors[index];
        }
        secretSimonSaysPattern = secretOrder;
    }

    public static void createSecretLevers(int leverCount)
    {
        Color[] secretIndicators = new Color[leverCount];
        for (int i = 0; i < leverCount; i++)
        {
            secretIndicators[i] = Random.Range(0, 2) == 0 ? Color.blue : Color.black;
        }
        secretLeverPattern = secretIndicators;
    }

    public static void createCode(int length)
    {
        int[] code = new int[length];
        for (int i = 0; i < length; i++)
        {
            code[i] = Random.Range(1, 10);
        }
        secretCode = code;
    }

}
