using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WeightGauge : MonoBehaviour
{
    public float gaugeSpeed = 2.0f;
    public RectTransform arrow;
    public float minAngle = -90.0f;
    public float maxAngle = 90.0f;
    public TMP_text weightText;
    public GameObject gameManager;

    private bool isRunning = true;
    private bool movingUp = true;

    void Update()
    {
        if (isRunning)
        {
            float angle = arrow.localEulerAngles.z;
            if (angle > 180) angle -= 360;

            if (movingUp)
            {
                angle += gaugeSpeed * Time.deltaTime;
                if (angle >= maxAngle) movingUp = false;
            }
            else
            {
                angle -= gaugeSpeed * Time.deltaTime;
                if (angle <= minAngle) movingUp = true;
            }

            arrow.localEulerAngles = new Vector3(0, 0, angle);

            float weight = Mathf.Lerp(0, 60, (angle + 90) / 180);
            weightText.text = "Weight: " + weight.ToString("F1") + " kg";
        }
    }

    public void StopGauge()
    {
        isRunning = false;
        gameManager.GetComponent<WeightGameManager>().CheckWeight();
    }

    public void ResetGauge()
    {
        isRunning = true;
        movingUp = true;
        arrow.localEulerAngles = new Vector3(0, 0, minAngle);
    }
}

