using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scripts_Player_GenericInteractions : MonoBehaviour
{
    public TextMeshProUGUI PressE;
    // Start is called before the first frame update
    void Awake()
    {
        PressE.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Interactible")
        {
            PressE.gameObject.SetActive(false);
        }
        else
        {
            PressE.gameObject.SetActive(false);
        }
    }
}
