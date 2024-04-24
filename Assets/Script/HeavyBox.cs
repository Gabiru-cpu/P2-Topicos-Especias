using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBox : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isCollidingWithPlayer1 = false;
    private bool isCollidingWithPlayer2 = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            isCollidingWithPlayer1 = true;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            isCollidingWithPlayer2 = true;
        }

        if (!isCollidingWithPlayer1! && isCollidingWithPlayer2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        if (isCollidingWithPlayer1! && isCollidingWithPlayer2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
        if (!isCollidingWithPlayer1! && !isCollidingWithPlayer2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        if (isCollidingWithPlayer1 && isCollidingWithPlayer2)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            isCollidingWithPlayer1 = false;
        }
        if (collision.gameObject.CompareTag("Player2"))
        {
            isCollidingWithPlayer2 = false;
        }

        
    }
}
