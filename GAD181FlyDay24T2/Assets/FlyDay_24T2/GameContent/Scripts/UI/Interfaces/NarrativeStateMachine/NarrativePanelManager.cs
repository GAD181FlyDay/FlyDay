using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Narrative
{
    /// <summary>
    /// Resposible for displaying and hiding panels according to states requirements.
    /// </summary>

    public class NarrativePanelManager : MonoBehaviour
    {
        #region Variables.
        public TMP_Text narrativeText;
        public Image narrativeImage;
        #endregion

        private void Start()
        {
            // HidePanel();
        }

        #region Public Functions.
        public void ShowPanel(string narrative, Sprite image)
        {
            narrativeText.text = narrative;

            if (image != null)
            {
                narrativeImage.sprite = image;
                narrativeImage.enabled = true;
            }
            else
            {
                narrativeImage.enabled = false;
            }

            Time.timeScale = 0f;

            narrativeText.gameObject.SetActive(true);
            narrativeImage.gameObject.SetActive(narrativeImage.sprite != null);
        }

        public void HidePanel()
        {
            Time.timeScale = 1f;

            narrativeText.gameObject.SetActive(false);
            narrativeImage.gameObject.SetActive(false);
        }
        #endregion
    }
}