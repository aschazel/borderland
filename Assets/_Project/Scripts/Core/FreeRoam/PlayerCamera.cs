using UnityEngine;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles free roam player camera rotation behaviour.
    /// </summary>
    public class PlayerCamera : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private float mouseSensitivity = 2f;
        private float horizontalAxis;
        private float verticalAxis;
        private float xRotation;
        private float yRotation;

        [Header("Object References")]
        [SerializeField] private Transform playerOrientation;
        [SerializeField] private Transform playerCamera;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
            RotateCamera();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Get input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            horizontalAxis = Input.GetAxis("Mouse X") * mouseSensitivity;
            verticalAxis = Input.GetAxis("Mouse Y") * mouseSensitivity;
        }



        /// <summary>
        /// Rotates player around input axis.
        /// </summary>
        private void RotateCamera()
        {
            yRotation += horizontalAxis;
            xRotation -= verticalAxis;

            xRotation = Mathf.Clamp(xRotation, -85f, 85f);

            playerCamera.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            playerOrientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        #endregion
    }
}