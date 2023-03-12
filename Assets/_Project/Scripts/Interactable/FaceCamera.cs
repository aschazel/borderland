using UnityEngine;

namespace ProjectBorderland.Interactable
{
    /// <summary>
    /// Rotates object to always face camera.
    /// </summary>
    public class FaceCamera : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            LookAtCamera();
        }
        #endregion



        #region ProjectBorderland methods
        private void LookAtCamera()
        {
            transform.LookAt(Camera.main.transform);
        }
        #endregion
    }
}