using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    public Item Incense;
    public int SlotIndex;
    //public Image SlotImage;
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Click()
    {
        switch (SlotIndex)
        {
            case 1:
                playercontrller.Incense1 = Incense;
                dataManager.Slot1 = Incense;
                break;
            case 2:
                playercontrller.Incense2 = Incense;
                dataManager.Slot2 = Incense;
                break;
            case 3:
                playercontrller.Incense3 = Incense;
                dataManager.Slot3 = Incense;
                break;
            case 4:
                playercontrller.Incense4 = Incense;
                dataManager.Slot4 = Incense;
                break;
            default:
                break;
        }
    }

// Update is called once per frame
void Update()
    {
        
    }
}
