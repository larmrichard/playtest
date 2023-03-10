using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScens : MonoBehaviour
{
    // Start is called before the first frame update
    public string TargetScene;
    public string TargetSpawn;
  
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Player"))
        {
            PosController.Instance.TargetPos = TargetSpawn;
            SceneManager.LoadSceneAsync(TargetScene);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
