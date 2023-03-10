using UnityEngine;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles game overalls.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(GameManager).Name;
                        instance = newGameObject.AddComponent<GameManager>();
                    }
                }

                return instance;
            }
        }
        #endregion

        private PlayerController playerController;
        private PlayerCamera playerCamera;

        [Header("Object References")]
        [SerializeField] private GameObject playerObject;



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

            playerController = playerObject.GetComponent<PlayerController>();
            playerCamera = playerObject.GetComponent<PlayerCamera>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Enables player free roam movement.
        /// </summary>
        public static void EnableFreeRoamMovement()
        {
            instance.playerController.enabled = true;
        }


        /// <summary>
        /// Disables player free roam movement.
        /// </summary>
        public static void DisableFreeRoamMovement()
        {
            instance.playerController.enabled = false;
        }



        /// <summary>
        /// Enables player free roam camera.
        /// </summary>
        public static void EnableFreeRoamCamera()
        {
            instance.playerCamera.enabled = true;
        }


        /// <summary>
        /// Disables player free roam camera.
        /// </summary>
        public static void DisableFreeRoamCamera()
        {
            instance.playerCamera.enabled = false;
        }
        #endregion
    }
}