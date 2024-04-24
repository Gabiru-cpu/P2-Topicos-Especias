using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 300f;

    public Rigidbody2D rb;
    public Transform groundCheck;
    public bool isGrounded;
    public bool interact = false;

    public Animator animator;

    public GameObject gameOver;

    public List<AudioClip> audiosPlayer;
    public AudioSource audioSource;
    public AudioSource audioMusic;

    void Update()
    {
        float moveX = 0f;

        if (Input.GetKey(KeyCode.LeftArrow) && Time.timeScale > 0)
        {
            moveX = -1f;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && Time.timeScale > 0)
        {
            moveX = 1f;
            transform.localScale = new Vector2(1, 1);
        }

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        LayerMask layersToCheck = LayerMask.GetMask("Ground", "Box");
        isGrounded = Physics2D.Linecast(transform.position, groundCheck.position, layersToCheck);

        if (isGrounded)
        {
            animator.SetBool("jump", false);

            if (moveX == 0)
            {
                animator.SetBool("idle", true);
                animator.SetBool("run", false);
            }
            else
            {
                animator.SetBool("run", true);
                animator.SetBool("idle", false);
            }

        }
        else
        {
            animator.SetBool("jump", true);
            animator.SetBool("idle", false);
            animator.SetBool("run", false);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && Time.timeScale > 0)
        {
            audioSource.clip = audiosPlayer[0];
            audioSource.Play();

            rb.AddForce(Vector2.up * jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            interact = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            interact = false;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            audioMusic.clip = audiosPlayer[1];
            audioMusic.loop = false;
            audioMusic.Play();

            gameOver.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
