using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombinManager :  MonoBehaviour
{
    static CombinManager instance;
    public Inventory MyBag;
    public GameObject SlotGrid;
    public CombiSlot SlotPrefab;
    public Text ItemDescription;
    public Inventory ItemBin;
    public static int Item1Num;
    public GameObject Bag;
    public static Item CombinItem1;
    public Item CombinResult;
    public DataManager dataManager;



    void Awake()
   {
       if(instance!=null)
       Destroy(this);
       instance=this;
    

   }

   void Start()
   {
   }

   private void OnEnable()
   {
       //Debug.Log("合成面板打开"); 
       RefreshCombin();
       Time.timeScale=0f;
    //    instance.ItemDescription.text="";
       instance.Bag.SetActive(false);
   }

   private void OnDisable()
   {
        instance.Bag.SetActive(true);
   }

    public static void CreateNewSlot(Item item,int i)
   {
       CombiSlot NewSlot = Instantiate(instance.SlotPrefab,instance.SlotGrid.transform.position,Quaternion.identity);//新创建一个Slot对象到grid的位置
       NewSlot.gameObject.transform.SetParent(instance.SlotGrid.transform,false);//设置新创建的Slot为Grid的子对象
       NewSlot.SlotItem=item;
       NewSlot.SlotImage.sprite=item.ItemImage;
       NewSlot.HeldNumber.text=instance.MyBag.ItemHeld[i].ToString();//将背包里的物品数量传给UI按钮
   }

   public static void UpdateItemDescription(string ItemDescription)
   {
       instance.ItemDescription.text=ItemDescription;
   }



   public static void RefreshCombin()
   {

        for (int i = 0; i < instance.SlotGrid.transform.childCount; i++)//摧毁全部按钮
        {
            if (instance.SlotGrid.transform.childCount == 0)
                break;
            Destroy(instance.SlotGrid.transform.GetChild(i).gameObject);

        }
        for (int i = 0; i < instance.dataManager.BagSize; i++)//新建背包里有东西的按钮
        {
            if (instance.MyBag.ItemList[i])
            {
                CreateNewSlot(instance.MyBag.ItemList[i], i);
            }

        }

    }

    public static void Combination(Item CombinItem2)//合成函数
    {
        Debug.Log(CombinItem1.ItemName);
        Debug.Log(CombinItem2.ItemName);
        for (int i = 0; i < 20; i++)
        {
            if (CombinItem1.CombinList[i] == null)
            {
                if(i>19)
                {
                    Debug.Log("该物品无法合成");
                }                  
                instance.Bag.SetActive(true);
                break;
            }
            if (CombinItem1.CombinList[i] == CombinItem2)
            {
                instance.CombinResult = CombinItem1.CombinResult[i];
                
                for (int j = 0; j < instance.dataManager.BagSize; j++)
                {
                   
                    if (instance.MyBag.ItemList[j] == instance.CombinResult)//判断背包是否有结果道具且还有空位
                    {
                        if (instance.MyBag.ItemHeld[j] < instance.CombinResult.ItemMaxHeld)
                        {
                            for (int k = 0; k < instance.dataManager.BagSize; k++)//消耗道具1
                            {
                                if (instance.MyBag.ItemList[k] == CombinItem1)
                                {
                                    instance.MyBag.ItemHeld[k] = instance.MyBag.ItemHeld[k] - 1;
                                    break;
                                }
                            }
                            for (int l = 0; l < instance.dataManager.BagSize; l++)//消耗道具2
                            {
                                if (instance.MyBag.ItemList[l] == CombinItem2)
                                {
                                    instance.MyBag.ItemHeld[l] = instance.MyBag.ItemHeld[l] - 1;
                                    break;
                                }
                            }
                            instance.MyBag.ItemHeld[j]++;//合成结果道具持有+1
                            instance.Bag.SetActive(true);
                            break;

                        }
                    }
                    if (instance.MyBag.ItemList[j] == null)//判断背包是否还有有空位
                    {
                        for (int k = 0; k < instance.dataManager.BagSize; k++)//消耗道具1
                        {
                            if (instance.MyBag.ItemList[k] == CombinItem1)
                            {
                                instance.MyBag.ItemHeld[k] = instance.MyBag.ItemHeld[k] - 1;
                                break;
                            }
                        }
                        for (int l = 0; l < instance.dataManager.BagSize; l++)//消耗道具2
                        {
                            if (instance.MyBag.ItemList[l] == CombinItem2)
                            {
                                instance.MyBag.ItemHeld[l] = instance.MyBag.ItemHeld[l] - 1;
                                break;
                            }
                        }
                        instance.MyBag.ItemList[j] = instance.CombinResult;
                        instance.MyBag.ItemHeld[j] = 1;//合成结果道具数量+1
                        instance.Bag.SetActive(true);
                        break;
                    }
                    if (j == (instance.dataManager.BagSize-1))
                    {
                        Debug.Log("无法持有更多道具");
                        instance.Bag.SetActive(true);
                        break;
                    }

                }
 

            }
            if (i == 20)
            {
                Debug.Log("无法和此道具合成");
                instance.Bag.SetActive(true);
                break;
            }
        }

    }




    void Update()
   {

   }
  
}
