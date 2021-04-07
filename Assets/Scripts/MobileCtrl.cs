using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCtrl : MonoBehaviour
{

    public GameObject player;
    PlayerCtrl pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerCtrl>();
    }






    public void MobileMoveLeft()
    {
        pl.MobileMoveLeft();
    }
    public void MobileMoveRight()
    {
        pl.MobileMoveRight();
    }
    public void MobileStopMove()
    {
        pl.MobileStopMove();
    }
    public void MobileFireBullet()
    {
        pl.MobileFireBullet();
    }
    public void MobileJump()
    {
        pl.MobileJump();
    }
}
