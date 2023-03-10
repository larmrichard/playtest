using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour
{
    bool InPoint;
    public GameObject savePanel;
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
            savePanel.SetActive(true);


        }
    }
}
