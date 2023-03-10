using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YFlameContrller : MonoBehaviour
{
    public float DestroyTime;
    public float Speed;
    Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, DestroyTime);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    public void Move(Vector2 Direction)
    {
        rbody.AddForce(Direction * Speed);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
