using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerScript : NetworkBehaviour
{
    private int pointCount;

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
