using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PDSceneManager : MonoBehaviour
{
 
    public static void loadScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public static void exitGame()
    {
        Application.Quit();
    }

}
