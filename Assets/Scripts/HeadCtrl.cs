using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Breakable"))
        {
            gameObject.transform.parent.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            SFXCtrl.Instance.HandleCrate(collision.gameObject.transform.parent.position);
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
