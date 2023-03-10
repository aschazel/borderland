using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles player inspect object behaviour.
    /// </summary>
    public class InspectObject : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isInspecting;
        private float mouseSensitivity = 2f;
        private float horizontalAxis;
        private float verticalAxis;
        private float xRotation;
        private float yRotation;
        private GameObject inspectedObject;
        
        [Header("Object References")]
        [SerializeField] private Transform inspectorTransform;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
            Rotate();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(InputController.Instance.Inspect))
            {
                if (isInspecting)
                {
                    isInspecting = false;

                    GameManager.UndoFreezePlayer();
                    GameManager.UndoHidePlayerItemHolder();
                    
                    if (inspectedObject != null)
                    {
                        Destroy(inspectedObject);
                    }
                }

                else
                {
                    isInspecting = true;

                    GameManager.FreezePlayer();
                    GameManager.HidePlayerItemHolder();
                    Inspect();
                }
            }

            horizontalAxis = Input.GetAxis("Mouse X") * mouseSensitivity;
            verticalAxis = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }



        /// <summary>
        /// Inspects object.
        /// </summary>
        private void Inspect()
        {
            ItemSO item = InventoryManager.GetCurrentIndex();

            if (item != null)
            {
                inspectedObject = Instantiate(item.ModelObject, inspectorTransform.position, Quaternion.identity);
            }
        }



        /// <summary>
        /// Rotates object around input axis.
        /// </summary>
        private void Rotate()
        {
            if (isInspecting && inspectedObject != null)
            {
                yRotation += horizontalAxis;
                xRotation -= verticalAxis;

                inspectedObject.transform.Rotate(-Vector3.up * xRotation, Space.World);
                inspectedObject.transform.Rotate(-Vector3.right * yRotation, Space.World);
            }
        }
        #endregion
    }
}