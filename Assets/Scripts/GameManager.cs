using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static string CONNECTING_WIRES = "ConnectingWires";
    public static string SIMON_SAYS = "SimonSays";
    public static string LEVERS = "Levers";
    public static string CODE = "Code";
    public static string MAZE = "Maze";
    public static string CLICK_BUTTON = "ClickButton";
    [SerializeField] string playerTag;

    private List<PlayerScript> players;


    // Start is called before the first frame update
    void Start()
    {
        players = new List<PlayerScript>();
        foreach(GameObject go in GameObject.FindGameObjectsWithTag(playerTag))
        {
            players.Add(go.GetComponent<PlayerScript>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
