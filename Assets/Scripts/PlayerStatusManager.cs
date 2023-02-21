using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;

public class PlayerStatusManager : NetworkBehaviour
{
    private Image[] globalImages;

    private NetworkVariable<Image[]> playerStatusVar;
    private NetworkVariable<int> currentPlayers;

    void Awake()
    {
        globalImages = GameObject.Find("StatusImages").transform.GetComponentsInChildren<Image>();
        NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnect;
        NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnect;
    }

    public override void OnNetworkSpawn()
    {
        //playerStatusVar = new NetworkVariable<Image[]>(GameObject.Find("StatusImages").transform.GetComponentsInChildren<Image>());
        playerStatusVar = new NetworkVariable<Image[]>();
        currentPlayers = new NetworkVariable<int>(1);
    }

    private void OnClientConnect(ulong obj)
    {
        if (NetworkManager.Singleton.IsHost)
        {
            //On connect update the client with the new player count
            //Then it can update the screen

            //foreach (Image img in playerStatusVar.Value)
            //{
            //    if (img.color != Color.white)
            //    {
            //        img.color = Color.white;
            //        break;
            //    }
            //}
            currentPlayers.Value++;
        }
    }

    private void OnClientDisconnect(ulong obj)
    {
        if (NetworkManager.Singleton.IsHost)
        {
            //for (int i = playerStatusVar.Value.Length; i > 0; i--)
            //{
            //    if (playerStatusVar.Value[i].color == Color.white)
            //    {
            //        playerStatusVar.Value[i].color = Color.gray;
            //        break;
            //    }
            //}
            currentPlayers.Value--;
        }
    }

    private void Update()
    {
        int status = 0;
        foreach (Image img in globalImages)
        {
            if (status < currentPlayers.Value)
            {
                img.color = Color.white;
                status++;
            }
            else
            {
                img.color = Color.gray;
            }
        }
    }
}
