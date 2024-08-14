using UnityEngine;

public class OverrideableInteractionBase : MonoBehaviour
{
    public virtual void Interact()
    {
        Debug.Log("touched lmao");
    }
}
