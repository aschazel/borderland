// Author   : Rifqi Candra

using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles player camera rotation behaviour.
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
        private TextMeshProUGUI debugText;

        [Header("Object Attachments")]
        [SerializeField] private Transform orientation;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            debugText = DebugController.Instance.DebugText.transform.Find("PlayerCamera").GetComponent<TextMeshProUGUI>();
        }



        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }



        private void Update()
        {
            GetInput();
            RotatePlayer();
            SetDebugText();
        }
        #endregion



        #region Project
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
        private void RotatePlayer()
        {
            yRotation += horizontalAxis;
            xRotation -= verticalAxis;

            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
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

                text = $"Input mouse horizontal axis: {horizontalAxis}\n";
                text += $"Input mouse vertical axis: {verticalAxis}\n";

                debugText.SetText(text);
            }
        }
        #endregion
    }
}