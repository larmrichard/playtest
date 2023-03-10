using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateKeyPanel : MonoBehaviour
{
    public Inventory MyBag;
    public DataManager dataManager;
    public GameObject ButtonA;
    public GameObject ButtonB;
    public GameObject ButtonC;
    public GameObject ButtonD;
    public Item KeyA;
    public Item KeyB;
    public Item KeyC;
    public Item KeyD;
    bool HaveKey;
    // Start is called before the first frame update
    void Start()
    {


    }
    public void CreatButton()
    {
        for (int i = 0; i < dataManager.BagSize; i++)
        {
            if (MyBag.ItemList[i] == KeyA)
            {
                ButtonA.SetActive(true);
                HaveKey = true;
            }
        }
        for (int i = 0; i < dataManager.BagSize; i++)
        {
            if (MyBag.ItemList[i] == KeyB)
            {
                ButtonB.SetActive(true);
                HaveKey = true;
            }
        }
        for (int i = 0; i < dataManager.BagSize; i++)
        {
            if (MyBag.ItemList[i] == KeyC)
            {
                ButtonC.SetActive(true);
                HaveKey = true;
            }
        }
        for (int i = 0; i < dataManager.BagSize; i++)
        {
            if (MyBag.ItemList[i] == KeyD)
            {
                ButtonD.SetActive(true);
                HaveKey = true;
            }
        }
        if (!HaveKey)
        {
            Debug.Log("未持有任何钥匙");
        }
    }
    private void OnEnable()
    {
        ButtonA.SetActive(false);
        ButtonB.SetActive(false);
        ButtonC.SetActive(false);
        ButtonD.SetActive(false);
        HaveKey = false;
        CreatButton();
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
        ButtonA.SetActive(false);
        ButtonB.SetActive(false);
        ButtonC.SetActive(false);
        ButtonD.SetActive(false);
        HaveKey = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
