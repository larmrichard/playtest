using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    public int SlotIndex;
    public Image SlotImage;
    public Item Incense;
    //public Sprite Sprite1;
    //public Sprite Sprite2;
    //public Sprite Sprite3;
    //public Sprite Sprite4;
    //public Sprite Sprite5;
    public DataManager dataManager;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        switch (SlotIndex)
        {
            case 1:
                Incense = dataManager.Slot1;
                break;
            case 2:
                Incense = dataManager.Slot2;
                break;
            case 3:
                Incense = dataManager.Slot3;
                break;
            case 4:
                Incense = dataManager.Slot4;
                break;
            default:
                break;
          
        }
        SlotImage.sprite = Incense.ItemImage;
    }

   public void ImageChange()
    {
        switch (SlotIndex)
        {
            case 1:
                Incense = playercontrller.Incense1;
                break;
            case 2:
                Incense = playercontrller.Incense2;
                break;
            case 3:
                Incense = playercontrller.Incense3;
                break;
            case 4:
                Incense = playercontrller.Incense4;
                break;
            default:
                break;
        }
        SlotImage.sprite = Incense.ItemImage;
    }

    //void ImageChange1()
    //{
    //    SlotImage.sprite= Sprite1;
    //}
    //void ImageChange2()
    //{
    //    SlotImage.sprite = Sprite2;
    //}
    //void ImageChange3()
    //{
    //    SlotImage.sprite = Sprite3;
    //}
    //void ImageChange4()
    //{
    //    SlotImage.sprite = Sprite4;
    //}
    //void ImageChange5()
    //{
    //    SlotImage.sprite = Sprite5;
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
