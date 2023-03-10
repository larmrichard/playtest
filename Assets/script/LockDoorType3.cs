using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockDoorType3 : MonoBehaviour//用攻击的方式解锁的门
{
    [Header("攻击解锁的门")]
    public string TargetScene;
    public string TargetSpawn;
    public bool InDoor;
    public bool Lock;
    public int LockIndex;
    public DataManager dataManager;
    public Transform SpawnPoint;
    Transform player;



    // Start is called before the first frame update
    void Start()
    {
        InDoor=false;
        Lock= dataManager.LockList[LockIndex];
        player = GameObject.Find("player").transform;
    }
    void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Flame"))
        {
            Debug.Log("已解锁");
            if (Lock)
            {
                dataManager.LockList[LockIndex] = false;
                Lock = false;

            }
        }
        if (other.gameObject.CompareTag("Player"))
        {
            
        InDoor=true;

        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        InDoor=false;

        }
    }

    // Update is called once per frame
    void Update()
    {


        
        if( (Input.GetButtonDown("Fire1"))&&InDoor)
            {
             if(!Lock)
             {
                player.position = SpawnPoint.position;

            }
            else
            {
                Debug.Log("已上锁");
            }
             
            
            }


    }


}
