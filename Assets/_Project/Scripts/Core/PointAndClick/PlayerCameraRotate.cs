using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles player camera rotating movement in point and click mode.
    /// </summary>
    public class PlayerCameraRotate : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [HideInInspector] public float TopRotationLimit = 5f;
        [HideInInspector] public float BottomRotationLimit = 5f;
        [HideInInspector] public float RightRotationLimit = 5f;
        [HideInInspector] public float LeftRotationLimit = 5f;
        private float horizontalAxis;
        private float verticalAxis;
        private Vector3 smoothDampVelocity = Vector3.zero;

        [Header("Object References")]
        [SerializeField] private Transform playerCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float cursorBoundary = 10f;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            CheckMouseBoundary();
            RotateCamera();
        }
        #endregion



        #region ProjectBorderland methods
        private void CheckMouseBoundary()
        {
            Vector3 mousePosition = Input.mousePosition;

            if (mousePosition.y > Screen.height - cursorBoundary) verticalAxis = 1f;

            else if (mousePosition.y < cursorBoundary) verticalAxis = -1f;

            else verticalAxis = 0f;

            if (mousePosition.x > Screen.width - cursorBoundary) horizontalAxis = 1f;

            else if (mousePosition.x < cursorBoundary) horizontalAxis = -1f;

            else horizontalAxis = 0f;
        }



        /// <summary>
        /// Moves camera to input axes direction.
        /// </summary>
        private void RotateCamera()
        {
            ClampCamera();
            playerCamera.localRotation = Quaternion.Euler(playerCamera.eulerAngles.x - verticalAxis, playerCamera.eulerAngles.y + horizontalAxis, 0f);
        }
 


        /// <summary>
        /// Clamps camera movement to boundaries.
        /// </summary>
        private void ClampCamera()
        {
            if (horizontalAxis > 0f && playerCamera.eulerAngles.x >= RightRotationLimit)
            {
                horizontalAxis = 0f;
            }

            else if (horizontalAxis < 0f && playerCamera.eulerAngles.x <= LeftRotationLimit)
            {
                horizontalAxis = 0f;
            }

            if (verticalAxis > 0f && playerCamera.eulerAngles.y >= TopRotationLimit)
            {
                verticalAxis = 0f;
            }

            else if (verticalAxis < 0f && playerCamera.eulerAngles.y <= BottomRotationLimit)
            {
                verticalAxis = 0f;
            }
        }
        #endregion
    }
}