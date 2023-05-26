using UnityEngine;
using ProjectBorderland.Interaction;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles interation behaviour in free roam mode.
    /// </summary>
    public class Interaction : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private IInteractable item;

        [Header("Object References")]
        [SerializeField] private Transform freeRoamCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance = 5f;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
            item = DetectInteractable();
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
                Interact();
            }
        }



        /// <summary>
        /// Tries to interact with item in sight.
        /// </summary>
        private void Interact()
        {  
            if (item != null)
            {
                ItemSO heldItem = InventoryManager.GetCurrentIndex();

                if (!heldItem.IsNullItem)
                {
                    item.Interact(heldItem.Prefab);
                    InventoryManager.RemoveCurrentIndex();
                }

                else item.Interact();
            }
        }



        /// <summary>
        /// Returns interactable item in sight if detected by Raycast.
        /// </summary>
        private IInteractable DetectInteractable()
        {
            RaycastHit hit;
            Physics.Raycast(freeRoamCamera.position, freeRoamCamera.forward, out hit, interactDistance);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<IInteractable>() != null)
                {
                    IInteractable item = hit.collider.gameObject.GetComponent<IInteractable>();
                    PublishSubscribe.Instance.Publish(new ShowHoverTextMessage(item.InteractUIText));
                    return item;
                }
            }

            PublishSubscribe.Instance.Publish(new HideHoverTextMessage());
            return null;
        }
        #endregion
    }
}