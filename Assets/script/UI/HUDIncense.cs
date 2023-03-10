using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDIncense : MonoBehaviour
{
    public Image IncenseImage;
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        if(dataManager.Incense!=null)
        {
            IncenseImage.sprite = dataManager.Incense.ItemImage;
        }
    
    }
    void ImageChange()
    {
        if ((Input.GetKey("1")))//ÇÐ»»µ¯Ò©
        {
            IncenseImage.sprite = dataManager.Slot1.ItemImage;
        }
        if ((Input.GetKey("2")))
        {
            IncenseImage.sprite = dataManager.Slot2.ItemImage;
        }
        if ((Input.GetKey("3")))
        {
            IncenseImage.sprite = dataManager.Slot3.ItemImage;
        }
        if ((Input.GetKey("4")))
        {
            IncenseImage.sprite = dataManager.Slot4.ItemImage;
        }
    }
    // Update is called once per frame
    void Update()
    {
        ImageChange();
    }
}
