using UnityEngine;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Represents a dynamic object with states needs to be saved.
    /// </summary>
    public class DynamicObject : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isActive;
        public bool IsActive { get { return isActive; } }
        private SceneDataSO sceneDataSO;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            SceneLoadManager.OnLoadScene += SaveState;
        }



        private void OnDisable()
        {
            SceneLoadManager.OnLoadScene -= SaveState;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Saves object state.
        /// </summary>
        public virtual void SaveState()
        {

        }
        #endregion
    }
}