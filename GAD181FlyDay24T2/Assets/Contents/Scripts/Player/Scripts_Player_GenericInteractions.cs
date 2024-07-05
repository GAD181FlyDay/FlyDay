using System.Collections;
using System.Collections.Generic;
using TaxiMeter;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scripts_Player_GenericInteractions : MonoBehaviour
{
    public Transform playerModel;
    public TextMeshProUGUI PressE;
    public float InteractRange;
    public LayerMask interactibleLayer;
    private Scripts_Generic_InteractionBase currentInteraction;
    private int currentMinigameIndex;


    void Awake()
    {
        PressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        Ray interactRay = new Ray(playerModel.position, playerModel.forward);

        Debug.DrawLine(playerModel.position, playerModel.position + playerModel.forward * InteractRange, Color.red);

        if (Physics.Raycast(interactRay, out RaycastHit hitInfo, InteractRange, interactibleLayer))
        {
            if (hitInfo.collider.CompareTag("Interactible"))
            {
                PressE.gameObject.SetActive(true);
                currentInteraction = hitInfo.collider.GetComponent<Scripts_Generic_InteractionBase>();

            }
        }
        else
        {
            PressE.gameObject.SetActive(false);
        }

        if (PressE.gameObject.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("touched!");
            currentInteraction?.Interact();
        }
    }

    private void TaxiMeterMiniGameLoad()
    {
        if (currentMinigameIndex == 2)
        {
            SceneManager.LoadScene("TaxiMeterMinigame");
        }
    }
}
