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
        private bool isReadyToThrow;
        private float clickHoldTime;
        private Animator itemHolderAnimator;

        [Header("Object References")]
        [SerializeField] private Transform itemHolderTransform;
        [SerializeField] private float clickHoldTreshold = 0.6f;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            itemHolderAnimator = itemHolderTransform.GetComponentInChildren<Animator>();
        }



        private void Update()
        {
            GetInput();
        }



        private void OnEnable()
        {
            InventoryManager.OnEquippedChanged += Refresh;

            if (itemHolderTransform != null)
            {
                itemHolderTransform.gameObject.SetActive(true);
            }
        }



        private void OnDisable()
        {
            InventoryManager.OnEquippedChanged -= Refresh;

            if (itemHolderTransform != null)
            {
                itemHolderTransform.gameObject.SetActive(false);
            }
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                clickHoldTime = 0f;
                isReadyToThrow = false;
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                CheckThrowing();
            }

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                Throw();
            }
        }



        /// <summary>
        /// Checks if mouse button is being held long enough to throw item.
        /// </summary>
        private void CheckThrowing()
        {
            clickHoldTime += Time.deltaTime;

            if (clickHoldTime >= clickHoldTreshold)
            {
                isReadyToThrow = true;
                itemHolderAnimator.SetBool("IsReadyToThrow", true);
            }
        }



        /// <summary>
        /// Throws item on hand forward.
        /// </summary>
        public void Throw()
        {
            if (isReadyToThrow && heldItem != null)
            {
                ItemSO item = InventoryManager.GetCurrentIndex();
                GameObject throwedItem = InstantiatePickableItem(heldItem, item);
                throwedItem.GetComponent<Rigidbody>().AddForce(itemHolderTransform.forward * 5f, ForceMode.Impulse);

                Destroy(heldItem);

                InventoryManager.RemoveCurrentIndex();
            }

            itemHolderAnimator.SetBool("IsReadyToThrow", false);
        }



        /// <summary>
        /// Drops an item on ground.
        /// </summary>
        public void DropItem(ItemSO item)
        {
            GameObject itemModelObject = item.Prefab;
            InstantiatePickableItem(itemModelObject, item);
        }



        /// <summary>
        /// Instantiate item as pickable object.
        /// </summary>
        private GameObject InstantiatePickableItem(GameObject itemObject, ItemSO item)
        {
            GameObject instantiatedItem = Instantiate(itemObject, itemHolderTransform.position, itemHolderTransform.rotation);
            instantiatedItem.GetComponent<BoxCollider>().enabled = true;
            instantiatedItem.AddComponent<Rigidbody>();
            instantiatedItem.AddComponent<InteractableItem>();
            instantiatedItem.AddComponent<PickableBehaviour>().Item = item;
            instantiatedItem.name = item.Name;
            
            return instantiatedItem;
        }



        /// <summary>
        /// Refreshes item on player hand.
        /// </summary>
        public void Refresh()
        {   
            ItemSO item = InventoryManager.GetCurrentIndex();
            GameObject displayModel = item.GetPrefab();
            DisplayObject(displayModel);
        }



        /// <summary>
        /// Displays object into item holder if item is not null.
        /// </summary>
        private void DisplayObject(GameObject item)
        {
            if (item != null)
            {
                CheckOldItem();
                heldItem = Instantiate(item, itemHolderTransform.position, itemHolderTransform.rotation, itemHolderTransform); 
            }

            else
            {
                CheckOldItem();
            }
        }



        /// <summary>
        /// Checks and destroy old item on hand if present.
        /// </summary>
        private bool CheckOldItem()
        {
            if (heldItem != null)
            {
                Destroy(heldItem);
                return true;
            }

            else return false;
        }
        #endregion
    }
}