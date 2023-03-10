using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager :  MonoBehaviour
{
    static InventoryManager instance;
    public Inventory MyBag;
    public GameObject SlotGrid;
    public Slot SlotPrefab;
    public Text ItemDescription;
    public GameObject CombinPanel;
    public DataManager dataManager;
    public Inventory ItemBin;


    void Awake()
   {
       if(instance!=null)
       Destroy(this);
       instance=this;

   }
 

   private void OnEnable()//道具面板激活时关闭合成面板
   {
       //Debug.Log("道具面板打开"); 
       RefreshItem();
       Time.timeScale=0f;
       instance.ItemDescription.text="";
       CombinPanel.SetActive(false);

   }

   private void OnDisable()
   {
      Time.timeScale=1f; 
   }

   public static void UpdateItemDescription(string ItemDescription)
   {
       instance.ItemDescription.text=ItemDescription;
   }

   public static void CreateNewSlot(Item item,int i)
   {
       Slot NewSlot = Instantiate(instance.SlotPrefab,instance.SlotGrid.transform.position,Quaternion.identity);//新创建一个Slot对象到grid的位置
       NewSlot.gameObject.transform.SetParent(instance.SlotGrid.transform,false);//设置新创建的Slot为Grid的子对象
       NewSlot.SlotItem=item;
       NewSlot.SlotImage.sprite=item.ItemImage;
       NewSlot.HeldNumber.text=instance.MyBag.ItemHeld[i].ToString();//将背包里的物品数量传给UI按钮
   }

   public static void RefreshItem()
   {



        GameManagerContrller.Arrangement1();
        GameManagerContrller.Arrangement2();
        for (int i=0;i<instance.SlotGrid.transform.childCount;i++)//摧毁全部按钮
       {
           if(instance.SlotGrid.transform.childCount==0)
           break;
           Destroy(instance.SlotGrid.transform.GetChild(i).gameObject);

       }
       for(int i=0;i<instance.dataManager.BagSize;i++)//新建背包里有东西的按钮
       {
           if (instance.MyBag.ItemList[i])
           {
              CreateNewSlot(instance.MyBag.ItemList[i],i);
           }
           
       } 
   }

}
