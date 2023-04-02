using UnityEngine;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles first person player movement.
    /// </summary>
    public class PlayerMovement : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private float horizontalAxis;
        private float verticalAxis;
        private Rigidbody rb;
        private float moveSpeed;

        [Header("Object References")]
        [SerializeField] private Transform playerOrientation;

        [Header("Attribute Settings")]
        [SerializeField] private float walkSpeed;
        [SerializeField] private float sprintSpeed;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }



        private void FixedUpdate()
        {
            GetInput();
            Move();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Get input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKey(InputController.Instance.Forward)) verticalAxis = 1f;

            else if (Input.GetKey(InputController.Instance.Backward)) verticalAxis = -1f; 
            
            else verticalAxis = 0f;

            if (Input.GetKey(InputController.Instance.Right)) horizontalAxis = 1f;

            else if (Input.GetKey(InputController.Instance.Left)) horizontalAxis = -1f; 
            
            else horizontalAxis = 0f;


            if (Input.GetKey(InputController.Instance.Sprint))
            {
                moveSpeed = sprintSpeed;
            }

            else
            {
                moveSpeed = walkSpeed;
            }
        }



        /// <summary>
        /// Adds X, Z force to player based on received input.
        /// </summary>
        private void Move()
        {
            Vector3 moveDirection = playerOrientation.forward * verticalAxis + playerOrientation.right * horizontalAxis;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            ControlSpeed();
        }



        /// <summary>
        /// Sets player velocity to zero.
        /// </summary>
        public void Stop()
        {
            rb.velocity = Vector3.zero;
        }



        /// <summary>
        /// Clamps player velocity to moveSpeed value.
        /// </summary>
        private void ControlSpeed()
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }

            if (verticalAxis == 0f && horizontalAxis == 0f)
            {
                Stop();
            }
        }
        #endregion
    }
}