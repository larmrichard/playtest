using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairContrller_Up : MonoBehaviour
{
    // Start is called before the first frame update

    //public EdgeCollider2D edgecollider2;
    public playercontrller playercontrller;
    public bool AutoUp;
    

    void Start()
    {
        
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
    }

    private void OnCollisionStay2D(Collision2D other)

    {
        if (other.gameObject.CompareTag("Player") && playercontrller.Jump)
        {
                //Debug.Log("可以上楼");
            playercontrller.OnStair = true;

        }
        if (other.gameObject.CompareTag("Player") && AutoUp)
        {
                //Debug.Log("可以上楼");
            playercontrller.OnStair = true;

        }

    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
