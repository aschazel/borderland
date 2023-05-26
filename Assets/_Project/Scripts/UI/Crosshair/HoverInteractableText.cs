using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.UI.Crosshair
{
    /// <summary>
    /// Represents a pickable item.
    /// </summary>
    public class HoverInteractableText : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isShowing;

        [Header("Object References")]
        [SerializeField] private TextMeshProUGUI hoverText;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            ShowHoverText();
        }


        
        private void OnEnable()
        {
            PublishSubscribe.Instance.Subscribe<ShowHoverTextMessage>(UpdateHoverText);
            PublishSubscribe.Instance.Subscribe<HideHoverTextMessage>(HideHoverText);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<ShowHoverTextMessage>(UpdateHoverText);
            PublishSubscribe.Instance.Unsubscribe<HideHoverTextMessage>(HideHoverText);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates hover text according to interactable hover text.
        /// </summary>
        /// <param name="message"></param>
        private void UpdateHoverText(ShowHoverTextMessage message)
        {
            hoverText.text = message.text;
            isShowing = true;
        }



        /// <summary>
        /// Set hover text to hide.
        /// </summary>
        private void HideHoverText(HideHoverTextMessage message)
        {
            isShowing = false;
        }



        /// <summary>
        /// Shows hover text if interactable is detected.
        /// </summary>
        private void ShowHoverText()
        {
            if (isShowing)
            {
                hoverText.gameObject.SetActive(true);
            }

            else
            {
                hoverText.gameObject.SetActive(false);
            }
        }
        #endregion
    }
}