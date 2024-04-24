using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleporter1;
    public GameObject teleporter2;

    public AudioClip teleportSound;
    public AudioSource audioSource;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player1") && other.GetComponent<player1>().interact && other.GetComponent<player1>().isGrounded
            || other.CompareTag("Player2") && other.GetComponent<player2>().interact && other.GetComponent<player2>().isGrounded)
        {
            if (gameObject == teleporter1)
            {
                audioSource.clip = teleportSound;
                audioSource.Play();

                other.transform.position = teleporter2.transform.position;
            }
            else if (gameObject == teleporter2)
            {
                audioSource.clip = teleportSound;
                audioSource.Play();

                other.transform.position = teleporter1.transform.position;
            }
        }
    }
}
