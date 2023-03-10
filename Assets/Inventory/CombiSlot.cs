using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombiSlot : MonoBehaviour
{
   public Item SlotItem;
   public Inventory MyBag;
   public Image SlotImage;
   public int SlotNum;
   public Text HeldNumber;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public void ItemOnClicked()
   {
        CombinManager.Combination(SlotItem);
     
   }
}
