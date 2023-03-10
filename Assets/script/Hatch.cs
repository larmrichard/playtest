using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatch : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D boxcollider;
    public playercontrller playercontrller;
    void Start()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        boxcollider.enabled = true;
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playercontrller.OnStair)
        {
            boxcollider.enabled = false;
        }
        else
        {
            boxcollider.enabled = true;
        }
    }
}
