using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformLeftRight : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 5.0f;
    public bool isMovingRight = true;
    public bool isSnake = false;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

        if (isMovingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime; // Move a plataforma para cima

            if (transform.position.x >= startPosition.x + moveDistance) // Se a plataforma atingir o limite superior
            {
                isMovingRight = false; // Começa a mover para baixo
            }
        }
        else
        {
            transform.position -= Vector3.right * moveSpeed * Time.deltaTime; // Move a plataforma para baixo

            if (transform.position.x <= startPosition.x - moveDistance) // Se a plataforma atingir o limite inferior
            {
                isMovingRight = true; // Começa a mover para cima
            }
        }

        if (isMovingRight && isSnake) 
        {
            transform.localScale = new Vector2(-0.8f, transform.localScale.y); // Flip scale based on direction
        }
        else if (!isMovingRight && isSnake) 
        {
            transform.localScale = new Vector2(0.8f, transform.localScale.y); // Flip scale based on direction
        }
    }
}
