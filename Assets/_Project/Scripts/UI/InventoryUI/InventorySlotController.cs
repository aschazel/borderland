using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.UI
{
    /// <summary>
    /// Handles inventory slot behaviour.
    /// </summary>
    public class InventorySlotController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private List<Transform> slots = new List<Transform>();

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            GetSlots();
        }



        private void OnEnable()
        {
            InventoryManager.OnInventoryChanged += Refresh;
        }



        private void OnDisable()
        {
            InventoryManager.OnInventoryChanged -= Refresh;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Get inventory slots UI Transform.
        /// </summary>
        private void GetSlots()
        {
            foreach (Transform child in transform)
            {
                slots.Add(child);
            }
        }



        /// <summary>
        /// Refreshes inventory UI on inventory changed.
        /// </summary>
        private void Refresh()
        {
            int slotIndex = 0;

            foreach (Transform slot in slots)
            {
                AssignSprite(slot, slotIndex);
                slotIndex++;
            }
        }



        /// <summary>
        /// Updates slot sprite.
        /// </summary>
        /// <param name="slot"></param>
        private void AssignSprite(Transform slot, int slotIndex)
        {
            ItemDisplayController display = slot.gameObject.GetComponent<ItemDisplayController>();
            Sprite sprite = InventoryManager.GetSprite(slotIndex);

            display.UpdateSprite(sprite);
        }
        #endregion
    }
}