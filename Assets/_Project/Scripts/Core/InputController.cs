using System.Collections;
using UnityEngine;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles game debug mode.
    /// </summary>
    public class InputController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static InputController instance;
        public static InputController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InputController>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(InputController).Name;
                        instance = newGameObject.AddComponent<InputController>();
                    }
                }

                return instance;
            }
        }
        #endregion

        public KeyCode Interact;
        public KeyCode Forward;
        public KeyCode Backward;
        public KeyCode Right;
        public KeyCode Left;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            ParseKey();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Parse key inputs into Unity KeyCodes.
        /// </summary>
        private void ParseKey()
        {
            Interact = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("interactKey", "Mouse0"));
        }
        #endregion
    }
}