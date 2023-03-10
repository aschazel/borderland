using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Interactable;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles player item holder behaviour.
    /// </summary>
    public class PlayerItemHolder : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private GameObject heldItem;

        [SerializeField] private Transform playerItemHolderTransform;



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

            if (playerItemHolderTransform != null)
            {
                playerItemHolderTransform.gameObject.SetActive(true);
            }
        }



        private void OnDisable()
        {
            InventoryManager.OnEquippedChanged -= ChangeHeldItem;

            if (playerItemHolderTransform != null)
            {
                playerItemHolderTransform.gameObject.SetActive(false);
            }
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
                ItemSO item = InventoryManager.GetCurrentIndex();
                GameObject throwedItem = InstantiatePickableItem(heldItem, item);
                throwedItem.GetComponent<Rigidbody>().AddForce(playerItemHolderTransform.forward * 5f, ForceMode.Impulse);

                Destroy(heldItem);

                InventoryManager.RemoveCurrentIndex();
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
            GameObject instantiatedItem = Instantiate(itemObject, playerItemHolderTransform.position, playerItemHolderTransform.rotation);
            instantiatedItem.GetComponent<BoxCollider>().enabled = true;
            instantiatedItem.AddComponent<Rigidbody>();
            instantiatedItem.AddComponent<InteractableItem>();
            instantiatedItem.AddComponent<PickableBehaviour>().Item = item;
            instantiatedItem.name = item.Name;
            

            return instantiatedItem;
        }



        /// <summary>
        /// Changes item on player hand.
        /// </summary>
        private void ChangeHeldItem()
        {   
            ItemSO item = InventoryManager.GetCurrentIndex();
            GameObject displayModel = item.GetModelObject();
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
                    heldItem = Instantiate(item, playerItemHolderTransform.position, playerItemHolderTransform.rotation, playerItemHolderTransform);
                }

                else
                {
                    heldItem = Instantiate(item, playerItemHolderTransform.position, playerItemHolderTransform.rotation, playerItemHolderTransform);
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