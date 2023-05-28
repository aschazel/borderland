using UnityEngine;
using UnityEngine.UI;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.UI.Crosshair
{
    /// <summary>
    /// Handles crosshair behaviour.
    /// </summary>
    public class Crosshair : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Image crosshairImage;

        [Header("Object References")]
        [SerializeField] private HoverInteractableText hoverText;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            crosshairImage = GetComponent<Image>();
        }



        private void OnEnable()
        {
            PublishSubscribe.Instance.Subscribe<HideCrosshairMessage>(HideCrosshair);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<HideCrosshairMessage>(HideCrosshair);

        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Hides or shows crosshair.
        /// </summary>
        /// <param name="message"></param>
        private void HideCrosshair(HideCrosshairMessage message)
        {
            hoverText.enabled = message.isHiding;
            crosshairImage.enabled = message.isHiding;
        }
        #endregion
    }
}