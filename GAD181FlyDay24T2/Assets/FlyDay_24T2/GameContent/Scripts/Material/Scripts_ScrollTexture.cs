using UnityEngine;

namespace Texture
{
    /// <summary>
    /// Manippulates textures into looking like they're scrolling
    /// Attach to material object.
    /// </summary>

    public class Scripts_ScrollTexture : MonoBehaviour
    {
        [SerializeField] private float xScroll = 0.5f;
        [SerializeField] private float yScroll = 0f;

        private void Update()
        {
            float xOffset = Time.time * xScroll;
            float yOffset = Time.time * yScroll;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(xOffset, yOffset);
        }

        //void OnGUI()
        //{
        //    Debug.Log("OnGUI called in " + gameObject.name);
        //}

    }
}