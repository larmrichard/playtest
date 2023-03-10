using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamWaterContrller : MonoBehaviour
{
    public DataManager dataManager;
    [Header("�����ϵ�Կ������FunctionListInt�е�������")]
    public int KeyIndex;
    public GameObject Water;
    public GameObject Collider;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (dataManager.FunctionListInt[KeyIndex] != 0)
        {
            Water.SetActive(false);
            Collider.SetActive(false);
            dataManager.LockList[11] = false;
            dataManager.LockList[12] = false;
            dataManager.LockList[13] = false;
            dataManager.LockList[14] = false;
        }
        else
        {
            Water.SetActive(true);
            Collider.SetActive(true);
            dataManager.LockList[11] = true;
            dataManager.LockList[12] = true;
            dataManager.LockList[13] = true;
            dataManager.LockList[14] = true;
        }
    }
}
