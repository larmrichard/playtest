using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairContrller_Down_Nohatch : MonoBehaviour
{
    public playercontrller playercontrller;
    // Start is called before the first frame update
    void Start()
    {
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
    }
    private void OnCollisionStay2D(Collision2D other)

    {
        if (other.gameObject.CompareTag("Player") )
        {
            //Debug.Log("可以下楼");
            playercontrller.OnStair = true;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
