using TMPro;
using UnityEngine;

public class Scripts_Player_GenericInteractions : MonoBehaviour
{
    public Transform playerModel;
    public TextMeshProUGUI PressE;
    public float InteractRange = 0.9f;
    public LayerMask interactibleLayer;
    public KeyCode playerInteractionkey;

    private Scripts_Generic_InteractionBase _currentInteraction;

    void Awake()
    {
        if (PressE == null)
        {
            return;
        }

        PressE.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (PressE == null)
        {
            return;
        }

        Collider[] hitColliders = Physics.OverlapSphere(playerModel.position, InteractRange, interactibleLayer);

        bool interactibleFound = false;
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Interactible"))
            {
                PressE.gameObject.SetActive(true);
                _currentInteraction = hitCollider.GetComponent<Scripts_Generic_InteractionBase>();
                interactibleFound = true;
                break;
            }
        }

        if (!interactibleFound)
        {
            PressE.gameObject.SetActive(false);
        }

        if (PressE.gameObject.activeSelf && Input.GetKeyDown(playerInteractionkey))
        {
            Debug.Log("Interacted!");
            _currentInteraction?.Interact();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerModel.position, InteractRange);
    }
}


//private void TaxiMeterMiniGameLoad()
//{
//    if (currentMinigameIndex == 2)
//    {
//        SceneManager.LoadScene("TaxiMeterMinigame");
//    }
//}

