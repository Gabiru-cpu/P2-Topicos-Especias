using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPlayer1 : MonoBehaviour
{
    public Score scorePointer;

    public AudioClip coinSound;
    public AudioSource audioSource;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            audioSource.clip = coinSound;
            audioSource.Play();

            scorePointer.IncreaseScore(10);
            Destroy(gameObject);
        }
    }
}
