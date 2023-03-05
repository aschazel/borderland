using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Core;

namespace ProjectBorderland.Interactable
{
    /// <summary>
    /// Handles give item behaviour when interacted.
    /// </summary>
    public class GiveItemBehaviour : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private int giveCount;
        
        [Header("Object References")]
        [SerializeField] private ItemSO item;
        
        [Header("Attribute Configurations")]
        [SerializeField] private int maxGiveCount = 1;
        [SerializeField] private bool isInfiniteGive;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Gives an item to player inventory.
        /// </summary>
        public void Give()
        {
            if (giveCount < maxGiveCount || isInfiniteGive)
            {
                if (!InventoryManager.AddCurrentIndex(item))
                {
                    InventoryManager.Instance.PlayerItemHolder.DropItem(item);
                }

                giveCount++;
            }
        }
        #endregion
    }
}