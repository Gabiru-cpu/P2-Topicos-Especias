using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jail : MonoBehaviour
{
    private bool player1Inside = false;
    private bool player2Inside = false;

    public int toLevel = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = true;
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = true;
        }

        CheckPlayersInside();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            player1Inside = false;
        }
        else if (other.CompareTag("Player2"))
        {
            player2Inside = false;
        }

        CheckPlayersInside();
    }

    void CheckPlayersInside()
    {
        if (player1Inside && player2Inside)
        {
            SceneManager.LoadScene(toLevel);
        }
    }
}
