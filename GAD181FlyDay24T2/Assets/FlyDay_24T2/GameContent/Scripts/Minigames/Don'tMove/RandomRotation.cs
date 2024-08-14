using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RandomRotation : MonoBehaviour
{
    public bool hasRotated;
    public float rotationSpeed;
    public GameObject panel;
    public GameObject losePanel;
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(RotationLoop());
    }
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (hasRotated && horizontal > 0 || hasRotated && horizontal < 0 || hasRotated && vertical > 0 || hasRotated && vertical < 0)
        {
            panel.SetActive(true);
            losePanel.SetActive(true);
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }

        }
    }
    IEnumerator RotationLoop()
    {
        while (true)
        {
            float randomTime = Random.Range(2.0f, 15.0f);
            yield return new WaitForSeconds(randomTime);
            if (!hasRotated)
            {
                yield return RotateEnemy(180);
                hasRotated = true;
            }
            float randomTimeToBack = Random.Range(2.0f, 10f);
            yield return new WaitForSeconds(randomTimeToBack);
            if (hasRotated)
            {
                yield return RotateEnemy(-180);
                hasRotated = false;
            }
        }
    }
    IEnumerator RotateEnemy(float rotationAmount)
    {
        Quaternion rotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, rotationAmount);
        float timelapse = 0;

        while (timelapse < Mathf.Abs(rotationAmount) / rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(rotation, targetRotation, timelapse / (Mathf.Abs(rotationAmount) / rotationSpeed));
            timelapse += Time.deltaTime;
            yield return null;

        }
        transform.rotation = targetRotation;
    }
}
