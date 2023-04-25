using UnityEngine;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles point and click cursor interact behaviour.
    /// </summary>
    public class Interaction : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public Camera PointAndClickCamera;
        public string _LayerMask;

        

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
        /// Tries to interact with item on cursor position.
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
        /// Returns interactable item if clicked using Raycast.
        /// </summary>
        private IInteractable DetectInteractable()
        {
            Ray ray = PointAndClickCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<IInteractable>() != null && hit.collider.gameObject.layer == LayerMask.NameToLayer(_LayerMask))
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