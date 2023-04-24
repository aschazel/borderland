using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Core.Manager;

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
                    DisableInspecting();
                }

                else
                {
                    EnableInspecting();
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
        /// Enters inspecting mode.
        /// </summary>
        private void EnableInspecting()
        {
            ItemSO item = InventoryManager.GetCurrentIndex();

            if (!item.IsNullItem)
            {
                isInspecting = true;
                //GameManager.EnterInspectMode();
                InstantiateInspectedObject(item);
            }
        }



        /// <summary>
        /// Exits inspecting mode.
        /// </summary>
        private void DisableInspecting()
        {
            isInspecting = false;
            //GameManager.ExitInspectMode();
                    
            if (inspectedObject != null)
            {
                Destroy(inspectedObject);
            }
        }



        /// <summary>
        /// Inspects object.
        /// </summary>
        /// <param name="item"></param>
        private void InstantiateInspectedObject(ItemSO item)
        {
            inspectedObject = Instantiate(item.Prefab, inspectorTransform.position, Quaternion.identity);

        }



        /// <summary>
        /// Rotates inspected object around input axis.
        /// </summary>
        private void Rotate()
        {
            if (isInspecting && inspectedObject != null)
            {
                inspectedObject.transform.Rotate(Vector3.down, horizontalAxis, Space.World);
                inspectedObject.transform.Rotate(Vector3.right, -verticalAxis, Space.World);
            }
        }
        #endregion
    }
}