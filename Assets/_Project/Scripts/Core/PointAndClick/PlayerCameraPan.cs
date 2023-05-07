using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles player camera panning movement in point and click mode.
    /// </summary>
    public class PlayerCameraPan : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public Vector3 AnchoredPosition;
        private float horizontalAxis;
        private float verticalAxis;
        private Vector3 smoothDampVelocity = Vector3.zero;

        [Header("Object References")]
        [SerializeField] private Transform playerCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float topBoundaryThickness = 5f;
        [SerializeField] private float bottomBoundaryThickness = 5f;
        [SerializeField] private float rightBoundaryThickness = 5f;
        [SerializeField] private float leftBoundaryThickness = 5f;
        [SerializeField] private float screenBoundary = 10f;
        [SerializeField] private float cameraMoveSpeed = 10f;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            AnchoredPosition = playerCamera.position;
        }



        private void Update()
        {
            CheckMouseBoundary();
            MoveCamera();
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
        /// Moves camera to input axes direction.
        /// </summary>
        private void MoveCamera()
        {
            ClampCamera();

            Vector3 targetPosition = playerCamera.position + new Vector3(horizontalAxis, verticalAxis, 0f) * cameraMoveSpeed * Time.deltaTime;
            playerCamera.position = Vector3.SmoothDamp(playerCamera.position, targetPosition, ref smoothDampVelocity, 0.3f);
        }



        /// <summary>
        /// Gets boundary position related to camera position.
        /// </summary>
        /// <param name="anchor"></param>
        /// <param name="boundary"></param>
        private float GetBoundaryPosition(float anchor, float boundary)
        {
            return anchor + boundary;
        }



        /// <summary>
        /// Clamps camera movement to boundaries.
        /// </summary>
        private void ClampCamera()
        {
            if (horizontalAxis > 0f && playerCamera.position.x >= GetBoundaryPosition(AnchoredPosition.x, rightBoundaryThickness))
            {
                horizontalAxis = 0f;
            }

            else if (horizontalAxis < 0f && playerCamera.position.x <= GetBoundaryPosition(AnchoredPosition.x, -leftBoundaryThickness))
            {
                horizontalAxis = 0f;
            }

            if (verticalAxis > 0f && playerCamera.position.y >= GetBoundaryPosition(AnchoredPosition.y, topBoundaryThickness))
            {
                verticalAxis = 0f;
            }

            else if (verticalAxis < 0f && playerCamera.position.y <= GetBoundaryPosition(AnchoredPosition.y, -bottomBoundaryThickness))
            {
                verticalAxis = 0f;
            }
        }
        #endregion
    }
}