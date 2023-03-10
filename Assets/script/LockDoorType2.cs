using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockDoorType2 : MonoBehaviour//以机关的方式解锁的门
{
    [Header("以机关的方式解锁的门")]
    string TargetScene;
    string TargetSpawn;
    private bool InDoor;
    bool Lock;
    public int LockIndex;
    public DataManager dataManager;
    bool Latch;
    public Transform SpawnPoint;
    Transform player;



    // Start is called before the first frame update
    void Start()
    {
        InDoor=false;
        Lock= dataManager.LockList[LockIndex];
        player = GameObject.Find("player").transform;
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        InDoor=true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
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
             if(!dataManager.LockList[LockIndex])
             {
                player.position = SpawnPoint.position;

            }
             else
            {
                Debug.Log("已上锁");
            }
             
            
            }


        //    if( (Input.GetButtonDown("Fire1"))&&InDoor)
        //{
        //    if(Latch&&Lock)
        //    {
        //        Debug.Log("已解锁");
        //        dataManager.LockList[LockIndex]=false;
        //        Lock=false;

        //    }

        //}
            
    }


}
