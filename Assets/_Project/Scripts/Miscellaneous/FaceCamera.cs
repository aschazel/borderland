using UnityEngine;

namespace ProjectBorderland.Miscellaneous
{
    /// <summary>
    /// Rotates object to always face main camera.
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