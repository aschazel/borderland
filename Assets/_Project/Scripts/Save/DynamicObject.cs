using UnityEngine;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Represents a dynamic object with properties needs to be saved.
    /// </summary>
    public class DynamicObject : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Vector3 position;
        public Vector3 Position { get { return position; } }
        public Quaternion rotation;
        public Quaternion Rotation { get { return rotation; } }
        private bool isActive;
        public bool IsActive { get { return isActive; } }



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Loads this object's previous state.
        /// </summary>
        public void LoadState()
        {
            transform.position = position;
            transform.rotation = rotation;
        }



        /// <summary>
        /// Saves this object's previous state.
        /// </summary>
        public void SaveState()
        {
            position = transform.position;
            rotation = transform.rotation;
        }
        #endregion
    }
}