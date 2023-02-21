using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerScript : MonoBehaviour
{
    private int pointCount;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Player");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        pointCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getPoints()
    {
        return pointCount;
    }

}
