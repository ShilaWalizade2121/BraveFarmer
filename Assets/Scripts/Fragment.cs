using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fragment : MonoBehaviour
{

    Rigidbody2D rb;
    public Vector3 velocity;
    public float delay;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(velocity);
        Destroy(gameObject, delay);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
