using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Interaction
{
    /// <summary>
    /// Represents a pickable item.
    /// </summary>
    public class PickableItem : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public ItemSO ItemSO;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Picks up this item to player inventory.
        /// </summary>
        public void PickUp()
        {
            InventoryManager.AddCurrentIndex(ItemSO);
            Destroy(gameObject);
        }



        #region IInteractable
        public void Interact()
        {
            PickUp();
        }



        public void Interact(GameObject _object)
        {}
        #endregion
        #endregion
    }
}