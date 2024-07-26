using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractingPaint : MonoBehaviour
{
    [SerializeField] Sprite paint;
    [SerializeField] SpriteRenderer paintRenderer;
    float transparency = 1;
    [SerializeField] float fadeSpeed = 5;
    bool playerDetected;

    void EnablePaint()
    {
        paintRenderer.color = new Color(1f, 1f, 1f, 1);

    }

    private void Start()
    {
        paintRenderer.color = new Color(1f, 1f, 1f, 0);
        transparency = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && playerDetected == true )
        {
            EnablePaint();
        }
        FadePaint();

    }

    void FadePaint()
    {
        if (paintRenderer.color.a > 0)
        {
            transparency -= Time.deltaTime * fadeSpeed;
            paintRenderer.color = new Color(1f, 1f, 1f, transparency);
        }
        else if(paintRenderer.color.a <= 0)
        {
            transparency = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDetected = false;
        }
    }
}
