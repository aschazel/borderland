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
        private InteractableItem interactableItem;
        
        [Header("Object References")]
        [SerializeField] private ItemSO item;
        
        [Header("Attribute Configurations")]
        [SerializeField] private int maxGiveCount = 1;
        [SerializeField] private bool isInfiniteGive;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            interactableItem = GetComponent<InteractableItem>();
        }


        
        private void OnEnable()
        {
            interactableItem.OnItemInteract += Give;
        }



        private void OnDisable()
        {
            interactableItem.OnItemInteract -= Give;
        }
        #endregion



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