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
        private float mouseSensitivity = 6f;
        private float horizontalAxis;
        private float verticalAxis;
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

                    GameManager.EnablePlayerMovement();
                    GameManager.EnablePlayerItemHolder();
                    
                    if (inspectedObject != null)
                    {
                        Destroy(inspectedObject);
                    }
                }

                else
                {
                    isInspecting = true;

                    GameManager.DisablePlayerMovement();
                    GameManager.DisablePlayerItemHolder();
                    Inspect();
                }
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                horizontalAxis = Input.GetAxis("Mouse X") * mouseSensitivity;
                verticalAxis = Input.GetAxis("Mouse Y") * mouseSensitivity;
            }

            else
            {
                horizontalAxis = 0f;
                verticalAxis = 0f;
            }
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
                inspectedObject.transform.Rotate(Vector3.down, horizontalAxis, Space.World);
                inspectedObject.transform.Rotate(Vector3.right, verticalAxis, Space.World);
            }
        }
        #endregion
    }
}