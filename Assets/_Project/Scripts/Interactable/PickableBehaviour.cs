using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Interactable
{
    /// <summary>
    /// Handles item pickable behaviour.
    /// </summary>
    public class PickableBehaviour : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] public ItemSO Item;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        public void PickUp()
        {
            if (!InventoryManager.AddCurrentIndex(Item))
            {
                int equippedSlotIndex = InventoryManager.EquippedSlotIndex;

                ItemSO droppedItem = InventoryManager.Items[equippedSlotIndex];
                InventoryManager.Instance.PlayerItemHolder.DropItem(droppedItem);

                InventoryManager.RemoveCurrentIndex();
                InventoryManager.AddCurrentIndex(Item);
            }

            Destroy(gameObject);
        }
        #endregion
    }
}