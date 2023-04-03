using UnityEngine;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Moves camera to player camera position.
    /// </summary>
    public class MoveCamera : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object Attachments")]
        [SerializeField] private Transform cameraTransform;

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            Move();
        }
        #endregion

        #region Project
        /// <summary>
        /// Moves camera to player camera position.
        /// </summary>
        private void Move()
        {
            transform.position = cameraTransform.position;
            transform.rotation = cameraTransform.rotation;
        }
        #endregion
    }
}
