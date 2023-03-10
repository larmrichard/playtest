using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairContrller_Down : MonoBehaviour
{
    // Start is called before the first frame update
    //public EdgeCollider2D edgecollider2D;
    public BoxCollider2D boxcollider2D;
    public playercontrller playercontrller;

    void Start()
    {
     
        boxcollider2D = GameObject.Find("Hatch").GetComponent<BoxCollider2D>();
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
    }

    private void OnCollisionStay2D(Collision2D other)

    {
        if (other.gameObject.CompareTag("Player") && playercontrller.Jump)
        {

            //Debug.Log("可以下楼");
            playercontrller.OnStair = true;
          
            boxcollider2D.enabled = false;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
