using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PDSceneManager : MonoBehaviour
{
    
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SceneManager");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void exitGame()
    {
        Application.Quit(0);
    }

}
