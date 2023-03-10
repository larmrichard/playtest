using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameContrller : MonoBehaviour
{
    public float DestroyTime;
    public float FlamePower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        Destroy(gameObject, DestroyTime);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
