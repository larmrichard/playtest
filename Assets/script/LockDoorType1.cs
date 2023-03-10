using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockDoorType1 : MonoBehaviour//以道具的方式解锁的门
{
    [Header("以道具的方式解锁的门")]
    public string TargetScene;
    public string TargetSpawn;
    private bool InDoor;
    public bool Lock;
    public Inventory MyBag;
    public Item Key;
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
                
             if(!Lock)
             {
                player.position = SpawnPoint.position;

            }
             else
             {
              Unlock();   
             }   
            
            }
    }

    void Unlock()
    {
         for(int i=0;i<dataManager.BagSize;i++)
         {
             if(MyBag.ItemList[i]==Key)
             {
                 Lock=false;
                 dataManager.LockList[LockIndex]=false;
                 Debug.Log("已解锁");
                break;
            }
            
             if(i== (dataManager.BagSize-1))
            {
                Debug.Log("已上锁");
                break;
            }
            

         }

    }
}
