using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.UI.Inventory
{
    /// <summary>
    /// Handles inventory slot behaviour.
    /// </summary>
    public class InventorySlotController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public List<Transform> slots = new List<Transform>();

        [Header("Object References")]
        [SerializeField] private RectTransform selector;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            PublishSubscribe.Instance.Subscribe<EquippedChangedMessage>(ShiftSelector);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<EquippedChangedMessage>(ShiftSelector);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Shift the slot selector to selected slot.
        /// </summary>
        private void ShiftSelector(EquippedChangedMessage message)
        {
            Transform equippedSlot = slots[message.SlotIndex];
            selector.anchoredPosition = equippedSlot.gameObject.GetComponent<RectTransform>().anchoredPosition;
        }
        #endregion
    }
}