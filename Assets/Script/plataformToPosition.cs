using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformToPosition : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Vector3 position1;
    public Vector3 position2;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = position1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == position1)
        {
            targetPosition = position2;
        }
        else if (transform.position == position2)
        {
            targetPosition = position1;
        }
    }
}
