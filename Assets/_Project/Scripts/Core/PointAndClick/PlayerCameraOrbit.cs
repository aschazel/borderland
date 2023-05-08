using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles player camera orbit movement in point and click mode.
    /// </summary>
    public class PlayerCameraOrbit : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public Transform Pivot;
        private float verticalAxis;
        private float horizontalAxis;

        [Header("Object References")]
        [SerializeField] private Transform playerCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float topRotationClamp = 5f;
        [SerializeField] private float bottomRotationClamp = 5f;
        [SerializeField] private float rightRotationClamp = 5f;
        [SerializeField] private float leftRotationClamp = 5f;
        [SerializeField] private float screenBoundary = 10f;
        [SerializeField] private float cameraMoveSpeed = 10f;



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

            if (mousePosition.y > Screen.height - screenBoundary) verticalAxis = 1f;

            else if (mousePosition.y < screenBoundary) verticalAxis = -1f;

            else verticalAxis = 0f;

            if (mousePosition.x > Screen.width - screenBoundary) horizontalAxis = 1f;

            else if (mousePosition.x < screenBoundary) horizontalAxis = -1f;

            else horizontalAxis = 0f;
        }



        /// <summary>
        /// Rotates camera to input axes direction.
        /// </summary>
        private void RotateCamera()
        {
            //ClampCamera();

            playerCamera.transform.RotateAround(Pivot.transform.position, Vector3.up, verticalAxis * cameraMoveSpeed);
            playerCamera.transform.RotateAround(Pivot.transform.position, Vector3.down, verticalAxis * cameraMoveSpeed);
        }



        // /// <summary>
        // /// Clamps camera movement to boundaries.
        // /// </summary>
        // private void ClampCamera()
        // {
        //     if (horizontalAxis > 0f && playerCamera.position.x >= GetBoundaryPosition(AnchoredPosition.x, rightBoundaryThickness))
        //     {
        //         horizontalAxis = 0f;
        //     }

        //     else if (horizontalAxis < 0f && playerCamera.position.x <= GetBoundaryPosition(AnchoredPosition.x, -leftBoundaryThickness))
        //     {
        //         horizontalAxis = 0f;
        //     }

        //     if (verticalAxis > 0f && playerCamera.position.y >= GetBoundaryPosition(AnchoredPosition.y, topBoundaryThickness))
        //     {
        //         verticalAxis = 0f;
        //     }

        //     else if (verticalAxis < 0f && playerCamera.position.y <= GetBoundaryPosition(AnchoredPosition.y, -bottomBoundaryThickness))
        //     {
        //         verticalAxis = 0f;
        //     }
        // }
        #endregion
    }
}