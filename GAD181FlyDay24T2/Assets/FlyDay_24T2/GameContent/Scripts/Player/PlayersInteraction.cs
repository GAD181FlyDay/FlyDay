using TMPro;
using UnityEngine;

public class PlayersInteraction : MonoBehaviour
{
    public Players selectedPlayers;
    public Transform playerModel;
    public TextMeshProUGUI PressE;

    [SerializeField] private float InteractRange = 0.9f;
    [SerializeField] private LayerMask interactibleLayer;

    private KeyCode _playerInteractionKey;
    private Scripts_InteractionBaseToOverride _currentInteraction;

    void Awake()
    {
        _playerInteractionKey = selectedPlayers == Players.one ? KeyCode.E : KeyCode.RightShift;

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
                _currentInteraction = hitCollider.GetComponent<Scripts_InteractionBaseToOverride>();
                interactibleFound = true;
                break;
            }  break;
        }

        if (!interactibleFound)
        {
            PressE.gameObject.SetActive(false);
        }

        if (PressE.gameObject.activeSelf && Input.GetKeyDown(_playerInteractionKey))
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
