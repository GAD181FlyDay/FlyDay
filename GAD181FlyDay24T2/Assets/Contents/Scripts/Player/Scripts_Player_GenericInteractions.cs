using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;




public class Scripts_Player_GenericInteractions : MonoBehaviour
{
    public Transform playerModel;
    public TextMeshProUGUI PressE;
    public float InteractRange;
    public LayerMask interactibleLayer;
    private Scripts_Generic_InteractionBase currentInteraction;
    void Awake()
    {
        PressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray interactRay = new Ray(playerModel.position, playerModel.forward);
        if(Physics.Raycast (interactRay, out RaycastHit hitInfo, InteractRange, interactibleLayer))
        {
            if (hitInfo.collider.CompareTag ("Interactible"))
            {
                PressE.gameObject.SetActive (true);
                currentInteraction = hitInfo.collider.GetComponent<Scripts_Generic_InteractionBase>(); ;
            }
        }
        else
        {
            PressE.gameObject.SetActive(false);
        }

        if (PressE.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            currentInteraction?.Interact();
        }
    }
}
