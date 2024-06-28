using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class Scripts_Player_GenericInteractions : MonoBehaviour
{
    public Transform playerModel;
    public TextMeshProUGUI PressE;
    public float InteractRange;
    void Awake()
    {
        PressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray interactRay = new Ray(playerModel.position, playerModel.forward);
        if(Physics.Raycast (interactRay, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.tag == "Interactible")
            {
                PressE.gameObject.SetActive (true);
            }
        }
        else
        {
            PressE.gameObject.SetActive(false);
        }
    }
}
