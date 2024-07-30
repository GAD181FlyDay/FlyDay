using UnityEngine;

public class Scripts_InteractionBaseToOverride : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("Touched lmao");
    }
}
