using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurboKeyHole : MonoBehaviour
{
    public DataManager dataManager;
    [Header("��LockList�е�������")]
    public int Index;
    public Inventory MyBag;
    public Item Key;
    public Image KeyHoleImage;
    [Header("��Կ��ʱͼƬ")]
    public Sprite KeyHoleSprite1;
    [Header("��Կ��ʱͼƬ")]
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
                    Debug.Log("�Ѳ���Կ��");

                    for (int k = 0; k < dataManager.BagSize; k++)//���ĵ���
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
                    Debug.Log("δ����Կ��");
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
                    Debug.Log("�޷����и�����Ʒ");
                    break;
                }

                if (MyBag.ItemList[i] == Key)
                {
                    if ((MyBag.ItemHeld[i] + 1) <= Key.ItemMaxHeld)
                    {
                        KeyHoleImage.sprite = KeyHoleSprite2;
                        dataManager.LockList[Index] = true;
                        Debug.Log("��õ���1");
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
                    Debug.Log("��õ���2");
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
