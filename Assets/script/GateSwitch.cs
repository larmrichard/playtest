using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateSwitch : MonoBehaviour
{
    bool InPoint;
    public GameObject Panel;
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        
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
