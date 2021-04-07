using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    public PlayerCtrl pl;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pl.isStuck = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        pl.isStuck = false;

    }

}
