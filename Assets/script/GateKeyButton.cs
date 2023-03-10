using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeyButton : MonoBehaviour
{
    //public GameObject KeyPanel;
    public GameObject gateKeyHole;
    GateKeyHole gateKeyHoleContrl;
    public DataManager dataManager;
    public Inventory MyBag;
    public Item Key;
    [Header("跟Key保持一致")]
    public int Index;
    [Header("开关上的钥匙在在FunctionListInt中的索引号")]
    public int KeyIndex;
    // Start is called before the first frame update
    void Start()
    {
        gateKeyHoleContrl = gateKeyHole.GetComponent<GateKeyHole>();
    }
    public void KeyIn()
    {
        for (int i = 0; i < dataManager.BagSize; i++)
        {
            if (MyBag.ItemList[i] == Key)
            {
                Debug.Log("已插入钥匙");

                for (int k = 0; k < dataManager.BagSize; k++)//消耗道具
                {
                    if (MyBag.ItemList[k] == Key)
                    {
                        MyBag.ItemList[k] = null;
                        MyBag.ItemHeld[k] = MyBag.ItemHeld[k] - 1;
                        GameManagerContrller.Arrangement1();
                        GameManagerContrller.Arrangement2();
                        dataManager.FunctionListInt[KeyIndex] = Index;
                        gateKeyHoleContrl.SetKeyIndex();
                        //KeyPanel.SetActive(false);
                        break;
                    }
                }
                break;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
