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
        [Header("Object References")]
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



        #region ProjectBorderland methods
        /// <summary>
        /// Moves camera to player camera position.
        /// </summary>
        private void Move()
        {
            transform.position = cameraTransform.position;
        }
        #endregion
    }
}