// Author   : Rifqi

using UnityEngine;

namespace ProjectBorderland.DeveloperTools
{
    /// <summary>
    /// Handles game debug mode.
    /// </summary>
    public class DebugMode : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static DebugMode instance;
        public static DebugMode Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<DebugMode>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(DebugMode).Name;
                        instance = newGameObject.AddComponent<DebugMode>();
                    }
                }

                return instance;
            }
        }
        #endregion

        public bool IsDebugMode = false;
        public GameObject DebugText;

        

        //==============================================================================
        // Functions
        //==============================================================================
    }
}