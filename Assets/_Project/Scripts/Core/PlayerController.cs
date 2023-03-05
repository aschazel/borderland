using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private float horizontalAxis;
        private float verticalAxis;
        private Rigidbody rb;
        private TextMeshProUGUI debugText;
        private float moveSpeed;

        [Header("Object References")]
        [SerializeField] private Transform orientation;

        [Header("Attribute Settings")]
        [SerializeField] private float originalMoveSpeed;
        [SerializeField] private float sprintSpeed;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            debugText = DebugController.Instance.DebugText.transform.Find("PlayerController").GetComponent<TextMeshProUGUI>();
            rb = gameObject.GetComponent<Rigidbody>();
        }



        private void FixedUpdate()
        {
            GetInput();
            Move();
            SetDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Get input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            horizontalAxis = Input.GetAxis("Horizontal");
            verticalAxis = Input.GetAxis("Vertical");

            if (Input.GetKey(InputController.Instance.Sprint))
            {
                moveSpeed = sprintSpeed;
            }

            else
            {
                moveSpeed = originalMoveSpeed;
            }
        }



        /// <summary>
        /// Adds X, Z force to player based on received input.
        /// </summary>
        private void Move()
        {
            Vector3 moveDirection = orientation.forward * verticalAxis + orientation.right * horizontalAxis;
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

            ControlSpeed();
        }



        /// <summary>
        /// Prevents player speed to exceeds moveSpeed value.
        /// </summary>
        private void ControlSpeed()
        {
            Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

            if (flatVelocity.magnitude > moveSpeed)
            {
                Vector3 limitedVelocity = flatVelocity.normalized * moveSpeed;
                rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
            }
        }
        #endregion



        #region Debug
        /// <summary>
        /// Sets debug text.
        /// </summary>
        private void SetDebugText()
        {
            if (DebugController.Instance.IsDebugMode)
            {
                string text;

                text = $"Input keyboard horizontal axis: {horizontalAxis}\n";
                text += $"Input keyboard vertical axis: {verticalAxis}\n";
                text += $"Rigidbody velocity: {rb.velocity}\n";
                text += $"Rigidbody drag: {rb.drag}\n";
                text += $"Coordinates: {transform.position}";

                debugText.SetText(text);
            }
        }
        #endregion
    }
}