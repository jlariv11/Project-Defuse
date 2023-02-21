using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class NetworkManagerUI : MonoBehaviour
{
    [SerializeField]
    private Button hostButton;
    [SerializeField]
    private Button clientButton;
    [SerializeField]
    private NetworkObject waitingPrefab;

    [SerializeField]
    private Button startGame;
    [SerializeField]
    private Button leaveGame;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("NetworkManager");

        if (objs.Length > 1)
        {
            Destroy(objs[1]);
        }
        DontDestroyOnLoad(objs[0]);

        hostButton.onClick.AddListener(() =>{
            NetworkManager.Singleton.StartHost();
        });
        clientButton.onClick.AddListener(() => {
            NetworkManager.Singleton.StartClient();
        });

        startGame.onClick.AddListener(() =>
        {
            if (NetworkManager.Singleton.IsHost)
            {
                NetworkManager.Singleton.SceneManager.LoadScene("Matchmaker", LoadSceneMode.Single);
                GetComponent<MatchmakerScript>().makeMatches();
            }
        });

        leaveGame.onClick.AddListener(() =>
        {
            // Do leave game stuff
        });
    }

}
