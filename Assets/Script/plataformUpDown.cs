using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformUpDown : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float moveDistance = 3f;
    public bool isMovingUp = true;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {

        if (isMovingUp)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime; // Move a plataforma para cima

            if (transform.position.y >= startPosition.y + moveDistance) // Se a plataforma atingir o limite superior
            {
                isMovingUp = false; // Começa a mover para baixo
            }
        }
        else
        {
            transform.position -= Vector3.up * moveSpeed * Time.deltaTime; // Move a plataforma para baixo

            if (transform.position.y <= startPosition.y - moveDistance) // Se a plataforma atingir o limite inferior
            {
                isMovingUp = true; // Começa a mover para cima
            }
        }
    }
}
