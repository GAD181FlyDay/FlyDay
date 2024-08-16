using JetBrains.Annotations;
using UnityEngine;

public class CursorEnabler : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Debug.Log("working??");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.M))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
