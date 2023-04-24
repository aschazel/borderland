using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Interaction;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles free roam item holder.
    /// </summary>
    public class PlayerItemHolder : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private GameObject heldItem;
        public GameObject HeldItem { get { return heldItem; } }
        private bool isReadyToThrow;
        private float clickHoldTime;
        private Animator itemHolderAnimator;

        [Header("Attribute Configurations")]
        [SerializeField] private string heldItemLayer = "HeldItem";
        [SerializeField] private string interactableLayer = "Interactable";

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
            InventoryManager.Instance.OnEquippedChanged += Refresh;
        }



        private void Update()
        {
            GetInput();
        }



        private void OnEnable()
        {
            if (itemHolderTransform != null)
            {
                itemHolderTransform.gameObject.SetActive(true);
            }
        }



        private void OnDisable()
        {
            InventoryManager.Instance.OnEquippedChanged -= Refresh;

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
        /// Refreshes item on player hand.
        /// </summary>
        public void Refresh()
        {   
            ItemSO item = InventoryManager.GetCurrentIndex();
            GameObject itemPrefab = item.GetPrefab();
            DisplayObject(itemPrefab);
        }



        /// <summary>
        /// Displays object into item holder if item is not null.
        /// </summary>
        private void DisplayObject(GameObject item)
        {
            if (item != null)
            {
                DestroyHeldItem();
                heldItem = Instantiate(item, itemHolderTransform.position, itemHolderTransform.rotation, itemHolderTransform);

                heldItem.layer = LayerMask.NameToLayer(heldItemLayer);
                heldItem.TryGetComponent<BoxCollider>(out BoxCollider collider);
                collider.enabled = false;
            }

            else
            {
                DestroyHeldItem();
            }
        }



        /// <summary>
        /// Destroys held item if present.
        /// </summary>
        private void DestroyHeldItem()
        {
            if (heldItem != null)
            {
                Destroy(heldItem);
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

                itemHolderAnimator.SetBool("IsReadyToThrow", false);
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
        private GameObject InstantiatePickableItem(GameObject itemObject, ItemSO itemSO)
        {
            GameObject instantiatedItem = Instantiate(itemObject, itemHolderTransform.position, itemHolderTransform.rotation);

            instantiatedItem.AddComponent<Rigidbody>();
            instantiatedItem.AddComponent<PickableItem>().ItemSO = itemSO;

            instantiatedItem.name = itemSO.Name;
            instantiatedItem.layer = LayerMask.NameToLayer(interactableLayer);
            
            return instantiatedItem;
        }
        #endregion
    }
}