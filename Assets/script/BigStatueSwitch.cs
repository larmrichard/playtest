using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStatueSwitch : MonoBehaviour
{
    bool InPoint;
    public GameObject Platform;
    [Header("同行的碰撞盒")]
    public GameObject Collider1;
    public GameObject Collider2;
    [Header("异行的碰撞盒")]
    public GameObject Collider3;
    public GameObject Collider4;
    private BoxCollider2D collider1;
    private BoxCollider2D collider2;
    private BoxCollider2D collider3;
    private BoxCollider2D collider4;
    public DataManager dataManager;
    Transform PlatformTransform;
    public Vector3 EndPos;
    public float Speed;
    bool Stop;
    [Header("平台在PositionList中的索引号")]
    public int Index;
    // Start is called before the first frame update
    void Start()
    {
        Stop = true;
        PlatformTransform = GameObject.Find("Platform").transform;
        collider1 = Collider1.GetComponent<BoxCollider2D>();
        collider2 = Collider2.GetComponent<BoxCollider2D>();
        collider3 = Collider3.GetComponent<BoxCollider2D>();
        collider4 = Collider4.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {

            InPoint = true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            InPoint = false;

        }
    }
    public void Move()
    {
 
            Stop = false;
            collider3.enabled = true;
            collider4.enabled = true;
       

    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && InPoint)
        {
            Move();
        }
            if (!Stop)
        {
            PlatformTransform.position = Vector3.MoveTowards(PlatformTransform.position, EndPos, Speed * Time.deltaTime);
            //Debug.Log("移动中");
        }
        if (PlatformTransform.position == EndPos && !Stop)
        {
            dataManager.PositionList[Index] = EndPos;
            Stop = true;
            //Debug.Log("停止");
            collider1.enabled = false;
            collider2.enabled = false;
        }
    }
}
