using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDoorCheck : MonoBehaviour
{
    public bool InDoor;
    // Start is called before the first frame update
    void Start()
    {

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
            Debug.Log("ÒÑÉÏËø");
        }
    }
}
