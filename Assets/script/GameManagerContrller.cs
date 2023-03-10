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
    public static void Arrangement1()//����������1
    {
        //Debug.Log("ִ�б���������1");
        for (int i = 0; i < instance.dataManager.BagSize; i++)
        {
            if(instance.mybag.ItemHeld[i] == 0)//ȥ������������Ϊ0����Ʒ
            {
                instance.mybag.ItemList[i] = null;
            }
        }
            for (int i = 0; i < instance.dataManager.BagSize; i++)//��MyBag�ĵ���ȫ���ѵ�ItemBin��
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
    public static void Arrangement2()//����������2
    {
        for (int i = 0; i < 20; i++)//��ItemBin��ĵ��ߴ��¶ѻص�MyBag��
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
    public void OpenView(bool pic)//�ĵ�ҳ����ƹ���
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
