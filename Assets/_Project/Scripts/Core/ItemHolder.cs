using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Core
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
        private static ItemHolder instance;
        public static ItemHolder Instance { get { return instance; } }



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            instance = this;
        }



        private void Update()
        {
            GetInput();
        }



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
            if (itemOnHand != null)
            {
                GameObject throwedItem = Instantiate(itemOnHand, transform.position, transform.rotation);
                Destroy(itemOnHand);

                throwedItem.AddComponent<Rigidbody>().AddForce(transform.forward * 5f, ForceMode.Impulse);

                int equippedSlotIndex = InventoryManager.EquippedSlotIndex;
                InventoryManager.Remove(equippedSlotIndex);
            }
        }



        /// <summary>
        /// Drops an item on ground.
        /// </summary>
        public static void DropItem(ItemSO item)
        {
            GameObject itemModelObject = item.ModelObject;
            GameObject droppedItem = Instantiate(itemModelObject, instance.transform.position, instance.transform.rotation);
            droppedItem.AddComponent<Rigidbody>();
        }



        /// <summary>
        /// Changes item on player hand.
        /// </summary>
        private void ChangeItemOnHand()
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