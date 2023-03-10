using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Slot : MonoBehaviour
{
   public Item SlotItem;
   public Inventory MyBag;
   public Image SlotImage;
   public Dropdown Dropdown;
   public GameManagerContrller gamemanager;
   public int SlotNum;
   public Text HeldNumber;
   


void Start()
    {
     gamemanager=GameObject.Find("GameManager").GetComponent<GameManagerContrller>();
    }

public void ValueChanged()
{
   if(Dropdown.value!=0)
{
    switch(Dropdown.value)
        {
            case 1:
               Debug.Log("使用"); 
               Dropdown.value=0;
                break;
            case 2:
                Debug.Log("组合");
                gamemanager.Combination.SetActive(true);
                CombinManager.CombinItem1 = SlotItem;
                Dropdown.value=0;
                break;
            case 3:
                Debug.Log("丢弃"); 
                MyBag.ItemList[SlotNum]=null;
                InventoryManager.RefreshItem();
                Dropdown.value=0;
                break;       
            default:
                break;
        }
}
}

   public void ItemOnClicked()
   {
      InventoryManager.UpdateItemDescription(SlotItem.ItemDescription);
   }


   void Update()
    {

    }
}
