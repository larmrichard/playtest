using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDoor : MonoBehaviour
{
    public bool InDoor;
    bool Lock;
    public DataManager dataManager;
    public int LockIndex;
    private BoxCollider2D Doorcollider;
    private BoxCollider2D Triggercollider;
    private BoxCollider2D Collider;
    public GameObject Door;
    public GameObject Trigger;
    // Start is called before the first frame update
    void Start()
    {
        Doorcollider= Door.GetComponent<BoxCollider2D>();
        Triggercollider= Trigger.GetComponent<BoxCollider2D>();
        Collider = GetComponent<BoxCollider2D>();
        Lock = dataManager.LockList[LockIndex];
        if(!Lock)
        {
            Doorcollider.enabled = false;
            Triggercollider.enabled = false;
            Collider.enabled = false;
        }
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

            Debug.Log("ÒÑ½âËø");
            dataManager.LockList[LockIndex] = false;
            Doorcollider.enabled = false;
            Triggercollider.enabled = false;
            Collider.enabled = false;
        }
    }
}
