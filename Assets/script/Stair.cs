using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour
{
    // Start is called before the first frame update
    private EdgeCollider2D edgecollider;
    public playercontrller playercontrller;
    void Start()
    {
        edgecollider = GetComponent<EdgeCollider2D>();
        edgecollider.enabled = false;
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
     }

    // Update is called once per frame
        void Update()
    {
        if(playercontrller.OnStair)
        {
            edgecollider.enabled = true;
        }
        else
        {
            edgecollider.enabled = false;
        }
    }
}
