using UnityEngine;

namespace ProjectBorderland.Core.Manager
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

        public KeyCode Forward;
        public KeyCode Backward;
        public KeyCode Right;
        public KeyCode Left;
        public KeyCode Sprint;
        public KeyCode Inspect;
        public KeyCode Slot0;
        public KeyCode Slot1;
        public KeyCode Slot2;
        public KeyCode Slot3;
        public KeyCode Slot4;
        public KeyCode Slot5;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            #region singletonDDOL
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion
            
            ParseKey();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Parse key inputs into Unity KeyCodes.
        /// </summary>
        private void ParseKey()
        {
            Forward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "W"));
            Backward = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("backwardKey", "S"));
            Right = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rightKey", "D"));
            Left = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("forwardKey", "A"));
            Sprint = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("sprintKey", "LeftShift"));
            Inspect = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("inspectKey", "E"));
            Slot0 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot1Key", "Alpha1"));
            Slot1 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot2Key", "Alpha2"));
            Slot2 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot3Key", "Alpha3"));
            Slot3 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot4Key", "Alpha4"));
            Slot4 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot5Key", "Alpha5"));
            Slot5 = (KeyCode) System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("slot6Key", "Alpha6"));
        }
        #endregion
    }
}