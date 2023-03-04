using UnityEngine;
using ProjectBorderland.InventorySystem;

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
        [Header("Object References")]
        [SerializeField] private ItemSO item;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Gives an item to player inventory.
        /// </summary>
        public void Give()
        {
            InventoryManager.Add(item);
        }
        #endregion
    }
}