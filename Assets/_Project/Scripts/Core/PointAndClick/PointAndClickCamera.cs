using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles point and click camera behaviour.
    /// </summary>
    public class PointAndClickCamera : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private float horizontalAxis;
        private float verticalAxis;
        private Transform cameraTransform;
        private Vector3 minimumCameraConstraint;
        private Vector3 maximumCameraConstraint;

        [Header("Attribute Configurations")]
        [SerializeField] private float speed;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
            PanCamera();
            ConstraintCameraMovement();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKey(InputController.Instance.Forward)) verticalAxis = 1f;

            else if (Input.GetKey(InputController.Instance.Backward)) verticalAxis = -1f; 
            
            else verticalAxis = 0f;

            if (Input.GetKey(InputController.Instance.Right)) horizontalAxis = 1f;

            else if (Input.GetKey(InputController.Instance.Left)) horizontalAxis = -1f; 
            
            else horizontalAxis = 0f;
        }



        /// <summary>
        /// Moves camera in panning manner.
        /// </summary>
        private void PanCamera()
        {
            Vector3 xAxis = transform.right * (horizontalAxis * speed * Time.deltaTime);
            Vector3 yAxis = transform.up * (verticalAxis * speed * Time.deltaTime);
            transform.position += xAxis + yAxis;
        }



        /// <summary>
        /// Sets up point and click camera position and constraints.
        /// </summary>
        public void SetUpCamera(Transform _cameraTransform, Vector3 _minimumCameraConstraint,  Vector3 _maximummCameraConstraint)
        {
            cameraTransform = _cameraTransform;
            minimumCameraConstraint = _minimumCameraConstraint;
            maximumCameraConstraint = _maximummCameraConstraint;

            MoveCamera();
        }



        /// <summary>
        /// Moves camera to camera transform.
        /// </summary>
        private void MoveCamera()
        {
            transform.position = cameraTransform.position;
            transform.rotation = cameraTransform.rotation;
        }



        /// <summary>
        /// Clamps camera movement to camera constraint values.
        /// </summary>
        private void ConstraintCameraMovement()
        {
            float clampedX = Mathf.Clamp(transform.position.x, cameraTransform.position.x - minimumCameraConstraint.x, cameraTransform.position.x + maximumCameraConstraint.x);
            float clampedY = Mathf.Clamp(transform.position.y, cameraTransform.position.y - minimumCameraConstraint.y, cameraTransform.position.y + maximumCameraConstraint.y);
            float clampedZ = Mathf.Clamp(transform.position.z, cameraTransform.position.z - minimumCameraConstraint.z, cameraTransform.position.z + maximumCameraConstraint.z);

            transform.position = new Vector3(clampedX, clampedY, clampedZ);
        }
        #endregion
    }
}