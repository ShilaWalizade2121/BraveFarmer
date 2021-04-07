using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    public Transform feet;
    public LayerMask whatIsOnGround;

    public float boostSpeed;
    public float jumpSpeed;
    public float feetRadius;
    public float boxWidth;
    public float boxHeight;
    public float delayDoubleJump;

    public bool isJump;
    public bool isGround;
    public bool canDoubleJump;
    public bool leftPressed;
    public bool rightPressed;
    public bool isStuck;

    public GameObject rightBullet, leftBullet;
    public Transform rightBulletSpawnerPosition, leftBulletSpawnerPosition; 


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapBox(new Vector2(feet.position.x, feet.position.y), new Vector2(boxWidth, boxHeight), 360.0f, whatIsOnGround);

        float playerSpeed = Input.GetAxisRaw("Horizontal");
        playerSpeed *= boostSpeed;
        if(playerSpeed != 0)
        {
            MoveHorizontal(playerSpeed);
        }
        else
        {
            StopMove();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        ShowFalling();
        if (Input.GetButtonDown("Fire1"))
        {
            FireBullet();
        }

        if (leftPressed)
        {
            MoveHorizontal(-boostSpeed);
        }

        if (rightPressed)
        {
            MoveHorizontal(boostSpeed);
        }


    }


    /// <summary>
    /// Move the gameobject in x-axis
    /// </summary>
    void MoveHorizontal(float playerSpeed)
    {
        rb.velocity = new Vector2(playerSpeed,rb.velocity.y);
        if (playerSpeed < 0)
        {
            sr.flipX = true;
        }
        else if (playerSpeed > 0)
        {
            sr.flipX = false;
        }
        if (!isJump)
        {
            anim.SetInteger("State", 1);

        }
    }

    /// <summary>
    /// Stop the gameobject
    /// </summary>
    void StopMove()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        if (!isJump)
        {
            anim.SetInteger("State", 0);

        }

    }

    void Jump()
    {
        if (isGround)
        {
            rb.AddForce(new Vector2(0, jumpSpeed));
            isJump = true;
            anim.SetInteger("State", 2);
            Invoke("EnableDoubleJump", delayDoubleJump);
        }
        if(!isGround && canDoubleJump)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpSpeed));
            isJump = true;
            anim.SetInteger("State", 2);
            canDoubleJump = false;
        }
        
    }

    void EnableDoubleJump()
    {
        canDoubleJump = true;
    }

    void ShowFalling()
    {
        if (rb.velocity.y < 0)
        {
            anim.SetInteger("State",3);
        }
    }


    void FireBullet()
    {
        if (!sr.flipX)
        {
            Instantiate(rightBullet, rightBulletSpawnerPosition.position, Quaternion.identity);
        }

        if (sr.flipX)
        {
            Instantiate(leftBullet, leftBulletSpawnerPosition.position, Quaternion.identity);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("MovingPlatform"))
        {
            isJump = false;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(feet.position, new Vector3(boxWidth, boxHeight, 0));

    }


    public void MobileMoveLeft()
    {
        leftPressed = true;
    }
    public void MobileMoveRight()
    {
        rightPressed = true;
    }
    public void MobileStopMove()
    {
        leftPressed = false;
        rightPressed = false;
        StopMove();
    }
    public void MobileFireBullet()
    {
        FireBullet();
    }
    public void MobileJump()
    {
        Jump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Coin":
                SFXCtrl.Instance.CoinSparkle(transform.position);
                GameCtrl.Instance.UpdateCoinCount();
                break;
            case "PowerUp":
                Vector3 powerupPosition = collision.transform.position;
                Destroy(collision.gameObject);
                SFXCtrl.Instance.Powerup(powerupPosition);
                break;
            default:
                print("Default");
                break;
        }
    }


}
