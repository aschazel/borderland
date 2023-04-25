using UnityEngine;
using UnityEngine.UI;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.UI.Inventory
{
    /// <summary>
    /// Handles item sprite display behaviour on UI.
    /// </summary>
    public class ItemDisplayController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Image image;

        [Header("Attribute Configurations")]
        [SerializeField] private int slotIndex;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            image = GetComponent<Image>();
            PublishSubscribe.Instance.Subscribe<InventoryChangedMessage>(UpdateImageUI);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<InventoryChangedMessage>(UpdateImageUI);
        }



        private void Update()
        {
            HideImage();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates item sprite in slot UI.
        /// </summary>
        /// <param name="newImage"></param>
        public void UpdateImageUI(InventoryChangedMessage message)
        {
            if (message.SlotIndex == slotIndex) image.sprite = message.Item.Sprite;
        }



        /// <summary>
        /// Hides image if item is empty.
        /// </summary>
        private void HideImage()
        {
            if (image.sprite == null)
            {
                image.enabled = false;
            }

            else
            {
                image.enabled = true;
            }
        }
        #endregion
    }
}