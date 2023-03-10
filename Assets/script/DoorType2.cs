using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorType2 : MonoBehaviour
{
    public bool InDoor;
    public Transform SpawnPoint;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {

            InDoor = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            InDoor = false;

        }
    }


    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && InDoor)
        {

            player.position = SpawnPoint.position;
        }
    }
}
