using UnityEngine;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles point and click cursor interact behaviour.
    /// </summary>
    public class CursorInteract : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance;
        [SerializeField] private LayerMask cursorInteractLayer;
        [SerializeField] private Camera pointAndClickCamera;

        

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
        /// Gets input from unity input manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                InteractClick();
            }
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                QuitPointAndClick();
            }
        }



        /// <summary>
        /// Tries to interact on cursor position.
        /// </summary>
        private void InteractClick()
        {
            ClickableObject clickableObject = DetectClickable();

            if (clickableObject != null)
            {
                clickableObject.Interact();
            }
        }



        /// <summary>
        /// Detects clickable on cursor position.
        /// </summary>
        private ClickableObject DetectClickable()
        {
            Ray ray = pointAndClickCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit, interactDistance, ~cursorInteractLayer);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<ClickableObject>() != null)
                {
                    ClickableObject clickableObject = hit.collider.gameObject.GetComponent<ClickableObject>();
                    return clickableObject;
                }

                return null;
            }

            return null;
        }



        /// <summary>
        /// Quit point and click mode.
        /// </summary>
        private void QuitPointAndClick()
        {
            //GameManager.SwitchGameState(GameState.FreeRoam);
        }
        #endregion
    }
}