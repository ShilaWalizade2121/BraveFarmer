using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour
{
    public Transform feet;
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            SFXCtrl.Instance.PlayerLands(feet.position);
        }

        if (collision.CompareTag("MovingPlatform"))
        {
            player.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingPlatform"))
        {
            player.transform.parent = null;
        }
    }




}
