using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamPlatform : MonoBehaviour
{
    public DataManager dataManager;
    [Header("ƽ̨��PositionList�е�������")]
    public int Index;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = dataManager.PositionList[Index];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
