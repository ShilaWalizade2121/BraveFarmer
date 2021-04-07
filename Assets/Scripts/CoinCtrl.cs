using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour
{

    public enum CoinMode
    {
        fly,
        vanish

    }

    public CoinMode mode;
    bool startFlying;
    GameObject coinMeter;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        coinMeter = GameObject.Find("Img_Coin");
    }

    // Update is called once per frame
    void Update()
    {
        if (startFlying)
        {
            transform.position = Vector3.Lerp(transform.position, coinMeter.transform.position, speed);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(CoinMode.vanish == mode)
            {
                Destroy(gameObject);

            }
            else if(CoinMode.fly == mode)
            {
                startFlying = true;
                gameObject.layer = 0;
            }
        }
    }

}
