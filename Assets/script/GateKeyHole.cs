using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GateKeyHole : MonoBehaviour
{
    public GameObject KeyPanel;
    public GameObject Panel;
    public DataManager dataManager;
    [Header("在FunctionListInt中的索引号")]
    public int KeyIndex;
    public Inventory MyBag;
    public Item Key;
    public Item Key1;
    public Item Key2;
    public Item Key3;
    public Item Key4;
    public Image KeyHoleImage;
    [Header("有钥匙时图片")]
    public Sprite KeyHoleSprite1;
    [Header("无钥匙时图片")]
    public Sprite KeyHoleSprite2;

    void Start()
    {
        SetKeyIndex();

    }
    public void SetKeyIndex()
    {
        switch (dataManager.FunctionListInt[KeyIndex])
        {
            case 0:
                Key = null;
                break;
            case 1:
                Key = Key1;
                break;
            case 2:
                Key = Key2;
                break;
            case 3:
                Key = Key3;
                break;
            case 4:
                Key = Key4;
                break;
            default:
                break;
        }

        if (dataManager.FunctionListInt[KeyIndex] == 0)
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

        if (dataManager.FunctionListInt[KeyIndex] !=0)
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

                        Debug.Log("获得道具1");
                        MyBag.ItemHeld[i] = MyBag.ItemHeld[i] + 1;
                        GameManagerContrller.Arrangement1();
                        GameManagerContrller.Arrangement2();
                        dataManager.FunctionListInt[KeyIndex] = 0;
                        break;
                    }
                }
                if (!MyBag.ItemList[i])
                {
                    KeyHoleImage.sprite = KeyHoleSprite2;

                    Debug.Log("获得道具2");
                    MyBag.ItemList[i] = Key;
                    MyBag.ItemHeld[i] = MyBag.ItemHeld[i] + 1;
                    GameManagerContrller.Arrangement1();
                    GameManagerContrller.Arrangement2();
                    dataManager.FunctionListInt[KeyIndex] = 0;
                    break;

                }


            }
        }
        else
        {
            KeyPanel.SetActive(true);
            Panel.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
