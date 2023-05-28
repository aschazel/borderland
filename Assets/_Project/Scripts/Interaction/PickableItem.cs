using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Save;

namespace ProjectBorderland.Interaction
{
    /// <summary>
    /// Represents a pickable item.
    /// </summary>
    public class PickableItem : DynamicObject, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public ItemSO ItemSO;
        private string interactUIText;
        private Vector3 lastPosition;
        private Quaternion lastRotation;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            GetComponent<BoxCollider>().enabled = true;
            interactUIText = $"Ambil {ItemSO.Name}";
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Picks up this item to player inventory.
        /// </summary>
        public void PickUp()
        {
            InventoryManager.AddCurrentIndex(ItemSO);
            //SaveManager.RemovePickableItem(this);
            Destroy(gameObject);
        }



        public override void SaveState()
        {
            //lastPosition =
        }



        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set { interactUIText = value; }
        }



        public void Interact()
        {
            PickUp();
        }



        public void Interact(ItemSO item)
        {}
        #endregion
        #endregion
    }
}