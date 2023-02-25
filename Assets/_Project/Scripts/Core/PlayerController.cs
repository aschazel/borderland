// Author   : Rifqi Candra

using UnityEngine;

    /// <summary>
    /// Handles player movement.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private float movementSpeed;
        private float horizontalAxis;
        private float verticalAxis;
        private Rigidbody rb;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
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
            horizontalAxis = Input.GetAxis("Horizontal");
            verticalAxis = Input.GetAxis("Vertical");
        }



        /// <summary>
        /// Move player based on received input.
        /// </summary>
        private void Move()
        {
            Vector3 movement = new Vector3(horizontalAxis, 0.0f, verticalAxis).normalized;
            rb.AddForce(movement * movementSpeed);

            SetDrag();
        }



        /// <summary>
        /// Sets Rigidbody's drag value based on received input.
        /// </summary>
        private void SetDrag()
        {
            if (Mathf.Approximately(horizontalAxis, 0f) && Mathf.Approximately(verticalAxis, 0f)) 
            {
                rb.drag = 10f;
            }

            else 
            {
                rb.drag = 0f;
            }
        }
        #endregion
    }