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
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {

        }



        /// <summary>
        /// Throws item on hand forward.
        /// </summary>
        public void Throw()
        {

        }



        /// <summary>
        /// Changes item on player hand.
        /// </summary>
        private void ChangeItemOnHand()
        {   
            int equippedSlotIndex = InventoryManager.EquippedSlotIndex;
            GameObject displayModel = InventoryManager.GetModel(equippedSlotIndex);
            DisplayModel(displayModel);
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
                    itemOnHand = Instantiate(item, transform.position, transform.rotation, transform);
                }

                else
                {
                    itemOnHand = Instantiate(item, transform.position, transform.rotation, transform);
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
        #endregion
    }
}