using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform p1, p2, startPos;
    public Vector3 nextPos;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

   

    void Update()
    {
        if(p1.position == transform.position)
        {
            nextPos = p2.position;
        }
        if (p2.position == transform.position)
        {
            nextPos = p1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);



    }
}
