using UnityEngine;
using ProjectBorderland.Interactable;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles player environment interaction behaviour.
    /// </summary>
    public class InteractEnvironment : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        
        [Header("Object References")]
        [SerializeField] private Transform playerCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(InputController.Instance.Interact))
            {
                Interact();
            }
        }



        /// <summary>
        /// Tries to interact with item in sight.
        /// </summary>
        private void Interact()
        {
            InteractableItem item = DetectInteractable();
                
            if (item != null)
            {
                item.Interact();
            }
        }



        /// <summary>
        /// Returns InteractableItem in sight if detected by Raycast.
        /// </summary>
        private InteractableItem DetectInteractable()
        {
            RaycastHit hit;
            Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, interactDistance);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<InteractableItem>() != null)
                {
                    InteractableItem item = hit.collider.gameObject.GetComponent<InteractableItem>();
                    return item;
                }

                return null;
            }

            return null;
        }
        #endregion
    }
}