using UnityEngine;
using ProjectBorderland.Interactable;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles interact by crosshair behaviour.
    /// </summary>
    public class FirstPersonInteract : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private Transform cameraTransform;

        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            Interact();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Tries to interact with item on sight.
        /// </summary>
        private void Interact()
        {
            if (Input.GetKey(InputController.Instance.Interact))
            {
                DetectInteractable();
            }
        }



        /// <summary>
        /// Detects interactable item on sight.
        /// </summary>
        private void DetectInteractable()
        {
            RaycastHit hit;
            Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<InteractableItem>() != null)
                {
                    InteractableItem item = hit.collider.gameObject.GetComponent<InteractableItem>();
                    item.Interact();
                }
            }
        }
        #endregion
    }
}