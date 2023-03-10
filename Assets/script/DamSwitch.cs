using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamSwitch : MonoBehaviour
{
    public GameObject Platform;
    [Header("同行的碰撞盒")]
    public GameObject Collider1;
    public GameObject Collider2;
    [Header("异行的碰撞盒")]
    public GameObject Collider3;
    public GameObject Collider4;
    Transform PlatformTransform;
    public Vector3 EndPos;
    public float Speed;
    bool Stop;
    private BoxCollider2D collider1;
    private BoxCollider2D collider2;
    private BoxCollider2D collider3;
    private BoxCollider2D collider4;
    public DataManager dataManager;
    [Header("在LockList中的索引号，与钥匙孔按钮的保持一致")]
    public int Index1;
    public int Index2;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        Stop = true;
        PlatformTransform = GameObject.Find("Platform").transform;
        collider1= Collider1.GetComponent<BoxCollider2D>();
        collider2 = Collider2.GetComponent<BoxCollider2D>();
        collider3 = Collider3.GetComponent<BoxCollider2D>();
        collider4 = Collider4.GetComponent<BoxCollider2D>();

    }
    public void Move()
    {
        if(!dataManager.LockList[Index1] && !dataManager.LockList[Index2])
        {
            Stop = false;
            collider3.enabled = true;
            collider4.enabled = true;
        }
        else
        {
            Debug.Log("没有反应");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!Stop)
        {
            PlatformTransform.position = Vector3.MoveTowards(PlatformTransform.position, EndPos, Speed * Time.deltaTime);
            //Debug.Log("移动中");
        }
        if (PlatformTransform.position == EndPos && !Stop)
        {
            dataManager.PositionList[0] = EndPos;
            Stop = true;
            //Debug.Log("停止");
            collider1.enabled = false;
            collider2.enabled = false;
        }
    }
}
