using UnityEngine;
using ProjectBorderland.Interaction;

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
        
        [Header("Object References")]
        [SerializeField] private Transform freeRoamCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance;
        [SerializeField] private LayerMask interactableLayer;


        
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
            IInteractable item = DetectInteractable();
                
            if (item != null)
            {
                item.Interact();
            }
        }



        /// <summary>
        /// Returns InteractableItem in sight if detected by Raycast.
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
                    return item;
                }

                return null;
            }

            return null;
        }
        #endregion
    }
}