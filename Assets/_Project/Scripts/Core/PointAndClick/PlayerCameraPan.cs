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
        [HideInInspector] public Vector3 AnchoredPosition;
        [HideInInspector] public float TopCameraBoundary = 5f;
        [HideInInspector] public float BottomCameraBoundary = 5f;
        [HideInInspector] public float RightCameraBoundary = 5f;
        [HideInInspector] public float LeftCameraBoundary = 5f;
        private float horizontalAxis;
        private float verticalAxis;
        private Vector3 smoothDampVelocity = Vector3.zero;

        [Header("Object References")]
        [SerializeField] private Transform playerCamera;

        [Header("Attribute Configurations")]
        [SerializeField] private float cursorBoundary = 10f;
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
        private void MoveCamera()
        {
            ClampCamera();

            float moveX = horizontalAxis * cameraMoveSpeed * Time.deltaTime;
            float moveY = verticalAxis * cameraMoveSpeed * Time.deltaTime;

            Vector3 targetPosition = playerCamera.position + playerCamera.right * moveX;
            targetPosition += playerCamera.up * moveY;

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
            if (horizontalAxis > 0f && playerCamera.position.x >= GetBoundaryPosition(AnchoredPosition.x, RightCameraBoundary))
            {
                horizontalAxis = 0f;
            }

            else if (horizontalAxis < 0f && playerCamera.position.x <= GetBoundaryPosition(AnchoredPosition.x, -LeftCameraBoundary))
            {
                horizontalAxis = 0f;
            }

            if (verticalAxis > 0f && playerCamera.position.y >= GetBoundaryPosition(AnchoredPosition.y, TopCameraBoundary))
            {
                verticalAxis = 0f;
            }

            else if (verticalAxis < 0f && playerCamera.position.y <= GetBoundaryPosition(AnchoredPosition.y, -BottomCameraBoundary))
            {
                verticalAxis = 0f;
            }
        }
        #endregion
    }
}