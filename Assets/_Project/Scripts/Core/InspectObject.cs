using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Core
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
        [SerializeField] private Transform playerTransform;
        public GameObject test;


        
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
                    //GameManager.EnableFreeRoamCamera();
                    //GameManager.EnableFreeRoamMovement();
                }

                else
                {
                    //GameManager.DisableFreeRoamCamera();
                    //GameManager.DisableFreeRoamMovement();
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
            isInspecting = true;
            ItemSO item = InventoryManager.GetCurrentIndex();
            inspectedObject = Instantiate(test, playerTransform.position, Quaternion.identity);
        }



        /// <summary>
        /// Rotates object around input axis.
        /// </summary>
        private void Rotate()
        {
            if (isInspecting)
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