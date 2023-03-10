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
        private InteractableItem interactableItem;
        
        [Header("Object References")]
        [SerializeField] public ItemSO Item;

        
        
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
            interactableItem.OnItemInteract += PickUp;
        }



        private void OnDisable()
        {
            interactableItem.OnItemInteract -= PickUp;
        }
        #endregion
        
        

        #region ProjectBorderland methods
        public void PickUp()
        {
            if (!InventoryManager.AddCurrentIndex(Item))
            {
                ItemSO droppedItem = InventoryManager.GetCurrentEquipped();
                InventoryManager.Instance.PlayerItemHolder.DropItem(droppedItem);

                InventoryManager.RemoveCurrentIndex();
                InventoryManager.AddCurrentIndex(Item);
            }

            Destroy(gameObject);
        }
        #endregion
    }
}