using UnityEngine;

namespace ProjectBorderland.DeveloperTools
{
    /// <summary>
    /// Handles game debug.
    /// </summary>
    public class DebugController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static DebugController instance;
        public static DebugController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<DebugController>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(DebugController).Name;
                        instance = newGameObject.AddComponent<DebugController>();
                    }
                }

                return instance;
            }
        }
        #endregion

        [Header("Attribute Settings")]
        public bool IsDebugMode;

        [Header("Object Attachments")]
        public GameObject DebugText;



        //==============================================================================
        // Functions
        //==============================================================================
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
        }
    }
}