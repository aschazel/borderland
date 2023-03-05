using UnityEngine;

namespace ProjectBorderland.InventorySystem
{
    /// <summary>
    /// Handles player first person item holder.
    /// </summary>
    public class ItemHolder : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private GameObject itemOnHand;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void OnEnable()
        {
            InventoryManager.OnEquippedChanged += ChangeItemOnHand;
        }



        private void OnDisable()
        {
            InventoryManager.OnEquippedChanged -= ChangeItemOnHand;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Changes item on player hand.
        /// </summary>
        private void ChangeItemOnHand()
        {           
            GameObject displayModel = GetModelFromEquipped();
            DisplayModel(displayModel);
        }



        /// <summary>
        /// Gets currently equipped item model.
        /// </summary>
        private GameObject GetModelFromEquipped()
        {
            int equippedSlotIndex = InventoryManager.EquippedSlotIndex;
            GameObject item = InventoryManager.GetModel(equippedSlotIndex);

            return item;
        }



        /// <summary>
        /// Displays item into item holder.
        /// </summary>
        private void DisplayModel(GameObject item)
        {
            if (item != null)
            {
                if (itemOnHand != null)
                {
                    Destroy(itemOnHand);
                    InstantiateModel(item);
                }

                else
                {
                    InstantiateModel(item);
                }    
            }

            else
            {
                if (itemOnHand != null)
                {
                    Destroy(itemOnHand);
                }
            }
        }



        /// <summary>
        /// Instantiate model.
        /// </summary>
        private void InstantiateModel(GameObject item)
        {
            itemOnHand = Instantiate(item, transform.position, transform.rotation, transform);
        }
        #endregion
    }
}