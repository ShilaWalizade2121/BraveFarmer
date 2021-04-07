using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralex : MonoBehaviour
{

    public float speed;
    Material mat;
    public float offset;
    public PlayerCtrl pl;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (!pl.isStuck)
        {
            if (pl.leftPressed)
            {
                offset += -speed;
            }
            else if (pl.rightPressed)
            {
                offset += speed;
            }
            offset += Input.GetAxisRaw("Horizontal") * speed;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }

      

    }
}
