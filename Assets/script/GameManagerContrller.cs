using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerContrller : MonoBehaviour
{
    static GameManagerContrller instance;
    public GameObject Combination;
    public GameObject MyBag;
    public GameObject FileList;
    public GameObject FileView;
    public GameObject PicView;
    public Inventory mybag;
    public static Item CombinItem1;
    public Inventory ItemBin;
    public DataManager dataManager;
    public static Item Incense;

    // Start is called before the first frame update
    void Awake()
   {
       if(instance!=null)
       Destroy(this);
       instance=this;
   }
    void Start()
    {
        
    }
    public static void Arrangement1()//背包整理函数1
    {
        //Debug.Log("执行背包整理函数1");
        for (int i = 0; i < instance.dataManager.BagSize; i++)
        {
            if(instance.mybag.ItemHeld[i] == 0)//去除背包里数量为0的物品
            {
                instance.mybag.ItemList[i] = null;
            }
        }
            for (int i = 0; i < instance.dataManager.BagSize; i++)//将MyBag的道具全部堆到ItemBin里
        {
            for (int j = 0; j < 20; j++)
            {
                if (instance.ItemBin.ItemList[j] == instance.mybag.ItemList[i])
                {
                    instance.ItemBin.ItemHeld[j] = instance.ItemBin.ItemHeld[j] + instance.mybag.ItemHeld[i];
                    instance.mybag.ItemList[i] = null;
                    instance.mybag.ItemHeld[i] = 0;
                    goto end;
                }
            }
            for (int k = 0; k < 20; k++)
            {
                if (instance.ItemBin.ItemList[k] == null)
                {
                    instance.ItemBin.ItemList[k] = instance.mybag.ItemList[i];
                    instance.ItemBin.ItemHeld[k] = instance.mybag.ItemHeld[i];
                    instance.mybag.ItemList[i] = null;
                    instance.mybag.ItemHeld[i] = 0;
                    break;
                }
            }
        end:;
        }
    }
    public static void Arrangement2()//背包整理函数2
    {
        for (int i = 0; i < 20; i++)//将ItemBin里的道具从新堆回到MyBag里
        {
            if (instance.ItemBin.ItemList[i] == null)
                break;
            if (instance.ItemBin.ItemHeld[i] > instance.ItemBin.ItemList[i].ItemMaxHeld)
            {
                for (int j = 0; j < instance.dataManager.BagSize; j++)
                {
                    if (instance.mybag.ItemList[j] == null)
                    {
                        instance.mybag.ItemList[j] = instance.ItemBin.ItemList[i];
                        instance.mybag.ItemHeld[j] = instance.ItemBin.ItemList[i].ItemMaxHeld;
                        instance.ItemBin.ItemHeld[i] = instance.ItemBin.ItemHeld[i] - instance.ItemBin.ItemList[i].ItemMaxHeld;
                        i--;
                        break;
                    }
                }
            }
            else
            {
                for (int j = 0; j < instance.dataManager.BagSize; j++)
                {
                    if (instance.mybag.ItemList[j] == null)
                    {
                        instance.mybag.ItemList[j] = instance.ItemBin.ItemList[i];
                        instance.mybag.ItemHeld[j] = instance.ItemBin.ItemHeld[i];
                        instance.ItemBin.ItemList[i] = null;
                        instance.ItemBin.ItemHeld[i] = 0;
                        break;
                    }
                }
            }
        }
    }
    public void OpenView(bool pic)//文档页面控制功能
    {
        if (pic)
        {
            instance.PicView.SetActive(true);
            instance.FileList.SetActive(false);
        }
        else
        {
            instance.FileView.SetActive(true);
            instance.FileList.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //Incense = dataManager.Incense;
    }
}
