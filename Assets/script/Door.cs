using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public string TargetScene;
    public string TargetSpawn;
    public bool InDoor;

    void Start()
    {
        InDoor=false;
    }


    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        InDoor=true;

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        InDoor=false;

        }
    }

     
          

    // Update is called once per frame
    void Update()
    {
       if( (Input.GetButtonDown("Fire1"))&&InDoor)
            {
                
                  PosController.Instance.TargetPos = TargetSpawn;
            SceneManager.LoadSceneAsync(TargetScene);
            }
    }
}
