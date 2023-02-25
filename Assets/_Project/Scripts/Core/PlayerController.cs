// Author   : Rifqi Candra

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
        [SerializeField] private float movementSpeed;
        private float horizontalAxis;
        private float verticalAxis;
        private Rigidbody rb;
        private TextMeshProUGUI debugText;

        //DEBUG
        private int debugger;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            debugText = DebugMode.Instance.DebugText.GetComponent<TextMeshProUGUI>();
            rb = gameObject.GetComponent<Rigidbody>();
        }



        private void Update()
        {
            SetDebugText();
            
            //DEBUG
            debugger++;
            Debug.Log(debugger);
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



        #region Debug
        /// <summary>
        /// Sets debug text values.
        /// </summary>
        private void SetDebugText()
        {
            if (DebugMode.Instance.IsDebugMode)
            {
                string text = debugText.text;

                text = text.Replace("VERTICALINPUTAXIS", $"{debugger}");
                text = text.Replace("HORIZONTALINPUTAXIS", $"{horizontalAxis}");
                text = text.Replace("RIGIDBODYDRAG", $"{rb.drag}");

                debugText.SetText(text);
            }
        }
        #endregion
    }
}