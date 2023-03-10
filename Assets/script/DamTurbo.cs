using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamTurbo : MonoBehaviour
{
    bool InPoint;
    public GameObject Panel;
    public DataManager dataManager;
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
    [Header("与按钮上的保持一致")]
    public Vector3 EndPos;
    // Start is called before the first frame update
    void Start()
    {
        collider1 = Collider1.GetComponent<BoxCollider2D>();
        collider2 = Collider2.GetComponent<BoxCollider2D>();
        collider3 = Collider3.GetComponent<BoxCollider2D>();
        collider4 = Collider4.GetComponent<BoxCollider2D>();
        if (dataManager.PositionList[0] == EndPos)
        {
            collider1.enabled = false;
            collider2.enabled = false;
            collider3.enabled = true;
            collider4.enabled = true;
        }
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
        // Update is called once per frame
        void Update()
    {
        if ((Input.GetButtonDown("Fire1")) && InPoint)
        {
            Panel.SetActive(true);


        }
    }
}
