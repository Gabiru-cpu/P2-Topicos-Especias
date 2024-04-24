using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateClick : MonoBehaviour
{
    public bool buttonOn = false;
    public float moveSpeed = 1f;

    private Vector2 initialPosition;
    public float moveDistance = 0.05f;

    public List<GameObject> objectsToDisable;
    public List<MonoBehaviour> scriptsToEnable;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        if (buttonOn && transform.position.y > initialPosition.y - moveDistance)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
        else if (!buttonOn && transform.position.y < initialPosition.y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2") || other.CompareTag("Box"))
        {
            buttonOn = !buttonOn;
            PlateAction();
        }
    }

    private void PlateAction()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(!obj.activeSelf); // Inverte o estado atual do objeto
        }

        foreach (MonoBehaviour script in scriptsToEnable)
        {
            script.enabled = !script.enabled; // Inverte o estado atual do script
        }
    }
}
