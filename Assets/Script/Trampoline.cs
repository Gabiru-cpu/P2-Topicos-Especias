using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public float bounceForce = 30f;

    public Animator animator;

    public AudioClip bounceSound;
    public AudioSource audioSource;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2" || collision.gameObject.tag == "Box")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            animator.SetBool("jumpePadActive", true);

            audioSource.clip = bounceSound;
            audioSource.Play();
        }
    }

    void endJumpPad () 
    {
        animator.SetBool("jumpePadActive", false);
    }
}
