using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
    public Item ThisItem;
    public Inventory MyBag;
    public bool Collide;
    public int ItemCount;//即将拾取的物品的数量
    public DataManager dataManager;
    [Header("在Item On World中的序号")]
    public int Index;

    // Start is called before the first frame update
    void Start()
    {
        if (!dataManager.ItemOnWorld[Index])
        {
            Destroy(gameObject);
        }
    }



     private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        Collide=true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        Collide=false;

        }
    }




    // Update is called once per frame
    void Update()
    {
        if(Collide&&(Input.GetButtonDown("Fire1")))
    {
        for(int i=0;i<20;i++)
        {
              if(i==(dataManager.BagSize))
            {
                Debug.Log("无法持有更多物品"); 
                break;
            }

 if(MyBag.ItemList[i]==ThisItem)
{
    if((MyBag.ItemHeld[i]+ItemCount)<=ThisItem.ItemMaxHeld)
    {
                        Debug.Log("获得道具1");
                        MyBag.ItemHeld[i]=MyBag.ItemHeld[i]+ItemCount;
                        dataManager.ItemOnWorld[Index] = false;
        Destroy(gameObject);
                        GameManagerContrller.Arrangement1();
                        GameManagerContrller.Arrangement2();
            break;
    }
}
            if(!MyBag.ItemList[i])
            {
                    Debug.Log("获得道具2");
                    MyBag.ItemList[i]=ThisItem;
            MyBag.ItemHeld[i]=MyBag.ItemHeld[i]+ItemCount;
                    dataManager.ItemOnWorld[Index] = false;
                    Destroy(gameObject);
                    GameManagerContrller.Arrangement1();
                    GameManagerContrller.Arrangement2();
                    break;

            }
          
           
        }
            
        
    }
        
    }
}
