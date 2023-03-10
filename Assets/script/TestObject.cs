using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestObject : MonoBehaviour
{
    static TestObject instance;

     void Awake()
   {
       if(instance!=null)
       Destroy(this);
       instance=this;
    

   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

private void OnEnable()
   {
       Debug.Log("测试对象打开"); 
   }

    // Update is called once per frame
    void Update()
    {
        
    }
}
