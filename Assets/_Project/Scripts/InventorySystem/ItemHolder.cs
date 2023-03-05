using UnityEngine;
using ProjectBorderland.Core;
using ProjectBorderland.Interactable;

namespace ProjectBorderland.InventorySystem
{
    /// <summary>
    /// Handles item holder  behaviour.
    /// </summary>
    public class ItemHolder : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private GameObject heldItem;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
        }



        private void OnEnable()
        {
            InventoryManager.OnEquippedChanged += ChangeHeldItem;
        }



        private void OnDisable()
        {
            InventoryManager.OnEquippedChanged -= ChangeHeldItem;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(InputController.Instance.Throw))
            {
                Throw();
            }
        }



        /// <summary>
        /// Throws item on hand forward.
        /// </summary>
        public void Throw()
        {
            if (heldItem != null)
            {
                int equippedSlotIndex = InventoryManager.EquippedSlotIndex;

                GameObject throwedItem = InstantiatePickableItem(heldItem, InventoryManager.Items[equippedSlotIndex]);
                throwedItem.GetComponent<Rigidbody>().AddForce(transform.forward * 5f, ForceMode.Impulse);

                Destroy(heldItem);

                InventoryManager.Remove(equippedSlotIndex);
            }
        }



        /// <summary>
        /// Drops an item on ground.
        /// </summary>
        public void DropItem(ItemSO item)
        {
            GameObject itemModelObject = item.ModelObject;
            InstantiatePickableItem(itemModelObject, item);
        }



        /// <summary>
        /// Instantiate item as pickable object.
        /// </summary>
        private GameObject InstantiatePickableItem(GameObject itemObject, ItemSO item)
        {
            GameObject instantiatedItem = Instantiate(itemObject, transform.position, transform.rotation);
            instantiatedItem.GetComponent<BoxCollider>().enabled = true;
            instantiatedItem.AddComponent<Rigidbody>();
            instantiatedItem.AddComponent<PickableBehaviour>().Item = item;
            instantiatedItem.AddComponent<InteractableItem>();
            

            return instantiatedItem;
        }



        /// <summary>
        /// Changes item on player hand.
        /// </summary>
        private void ChangeHeldItem()
        {   
            int equippedSlotIndex = InventoryManager.EquippedSlotIndex;
            GameObject displayModel = InventoryManager.GetModelObject(equippedSlotIndex);
            DisplayObject(displayModel);
        }



        /// <summary>
        /// Displays object into item holder.
        /// </summary>
        private void DisplayObject(GameObject item)
        {
            if (item != null)
            {
                if (heldItem != null)
                {
                    Destroy(heldItem);
                    heldItem = Instantiate(item, transform.position, transform.rotation, transform);
                }

                else
                {
                    heldItem = Instantiate(item, transform.position, transform.rotation, transform);
                }    
            }

            else
            {
                if (heldItem != null)
                {
                    Destroy(heldItem);
                }
            }
        }
        #endregion
    }
}