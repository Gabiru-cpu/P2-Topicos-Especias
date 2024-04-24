using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool leverOn = false;

    public Sprite leverBallOnSprite;
    public Sprite leverBallOffSprite;

    public SpriteRenderer spriteRenderer;

    public List<GameObject> objectsToDisable;
    public List<MonoBehaviour> scriptsToEnable;

    void OnTriggerEnter2D(Collider2D other)
    {        

        if (other.CompareTag("LeverOn"))
        {
            leverOn = true;
            spriteRenderer.sprite = leverBallOnSprite;
            LeverAction();
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LeverOn"))
        {
            leverOn = false;
            spriteRenderer.sprite = leverBallOffSprite;
            LeverAction();

        }
    }

    private void LeverAction()
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
