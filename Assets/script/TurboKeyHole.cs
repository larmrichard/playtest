using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboKeyHole : MonoBehaviour
{
    public DataManager dataManager;
    [Header("在LockList中的索引号")]
    public int Index;
    public Inventory MyBag;
    public Item Key;
    public Image KeyHoleImage;
    [Header("有钥匙时图片")]
    public Sprite KeyHoleSprite1;
    [Header("无钥匙时图片")]
    public Sprite KeyHoleSprite2;
    //bool KeyOut;
    // Start is called before the first frame update
    void Start()
    {
        if(dataManager.LockList[Index])
        {
            KeyHoleImage.sprite = KeyHoleSprite2;
        }
        else
        {
            KeyHoleImage.sprite = KeyHoleSprite1;
        }
    }
    public void KeyHole()
    {
        if(dataManager.LockList[Index])
        {
            for (int i = 0; i < dataManager.BagSize; i++)
            {
                if (MyBag.ItemList[i] == Key)
                {
                    dataManager.LockList[Index] = false;
                    KeyHoleImage.sprite = KeyHoleSprite1;
                    Debug.Log("已插入钥匙");

                    for (int k = 0; k < dataManager.BagSize; k++)//消耗道具
                    {
                        if (MyBag.ItemList[k] == Key)
                        {
                            MyBag.ItemList[k] = null;
                            MyBag.ItemHeld[k] = MyBag.ItemHeld[k] - 1;
                            GameManagerContrller.Arrangement1();
                            GameManagerContrller.Arrangement2();
                            break;
                        }
                    }
                    break;
                }

                if (i == (dataManager.BagSize - 1))
                {
                    Debug.Log("未持有钥匙");
                    break;
                }


            }
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                if (i == (dataManager.BagSize))
                {
                    Debug.Log("无法持有更多物品");
                    break;
                }

                if (MyBag.ItemList[i] == Key)
                {
                    if ((MyBag.ItemHeld[i] + 1) <= Key.ItemMaxHeld)
                    {
                        KeyHoleImage.sprite = KeyHoleSprite2;
                        dataManager.LockList[Index] = true;
                        Debug.Log("获得道具1");
                        MyBag.ItemHeld[i] = MyBag.ItemHeld[i] + 1;
                        GameManagerContrller.Arrangement1();
                        GameManagerContrller.Arrangement2();
                        break;
                    }
                }
                if (!MyBag.ItemList[i])
                {
                    KeyHoleImage.sprite = KeyHoleSprite2;
                    dataManager.LockList[Index] = true;
                    Debug.Log("获得道具2");
                    MyBag.ItemList[i] = Key;
                    MyBag.ItemHeld[i] = MyBag.ItemHeld[i] + 1;
                    GameManagerContrller.Arrangement1();
                    GameManagerContrller.Arrangement2();
                    break;

                }


            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
