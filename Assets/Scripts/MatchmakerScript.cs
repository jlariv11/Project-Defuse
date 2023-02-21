using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class MatchmakerScript : MonoBehaviour
{

    private GameObject[] players;
    private Dictionary<GameObject, GameObject> matches;

    public void makeMatches()
    {
        matches = new Dictionary<GameObject, GameObject>();
        players = GameObject.FindGameObjectsWithTag("Player");
        while (matches.Count != (players.Length / 2))
        {
            int index = Random.Range(0, players.Length);
            GameObject player = players[index];
            if (matches.ContainsKey(player) || matches.ContainsValue(player))
            {
                continue;
            }
            index = Random.Range(0, players.Length);
            GameObject partner = players[index];
            if (matches.ContainsKey(partner) || matches.ContainsValue(partner))
            {
                continue;
            }
            matches.Add(player, partner);
        }

        foreach (KeyValuePair<GameObject, GameObject> kvp in matches)
        {
            NetworkObject instructor = kvp.Key.GetComponent<NetworkObject>();
            NetworkObject defuser = kvp.Value.GetComponent<NetworkObject>();
            instructor.NetworkManager.SceneManager.LoadScene("InstructionScene", LoadSceneMode.Single);
            defuser.NetworkManager.SceneManager.LoadScene("SimonSays", LoadSceneMode.Single);

            print(kvp.Key.name + " with " + kvp.Value.name);
        }
    }
}
