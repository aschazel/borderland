using UnityEngine;
using ProjectBorderland.Core.FreeRoam;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles game states and overalls.
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

        private PlayerMovement playerMovement;
        private PlayerCamera playerCamera;
        private PlayerItemHolder playerItemHolder;
        private InteractEnvironment firstPersonInteractEnvironment;
        private GameState currentGameState;

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

            playerMovement = playerObject.GetComponentInChildren<PlayerMovement>();
            playerCamera = playerObject.GetComponentInChildren<PlayerCamera>();
            playerItemHolder = playerObject.GetComponentInChildren<PlayerItemHolder>();
            firstPersonInteractEnvironment = playerObject.GetComponentInChildren<InteractEnvironment>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Switchs current game state to specified game state.
        /// </summary>
        /// <param name="gameState"></param>
        public static void SwitchGameState(GameState gameState)
        {

        }



        /// <summary>
        /// Disables first person movement and camera movement.
        /// </summary>
        public static void DisablePlayerMovement()
        {
            instance.playerMovement.enabled = false;
            instance.playerCamera.enabled = false;
            instance.playerMovement.Stop();
        }



        /// <summary>
        /// Enables first person movement and camera movement.
        /// </summary>
        public static void EnablePlayerMovement()
        {
            instance.playerMovement.enabled = true;
            instance.playerCamera.enabled = true;
        }



        /// <summary>
        /// Disables player first person item holder.
        /// </summary>
        public static void DisablePlayerItemHolder()
        {
            instance.playerItemHolder.enabled = false;
        }



        /// <summary>
        /// Enables player first person item holder.
        /// </summary>
        public static void EnablePlayerItemHolder()
        {
            instance.playerItemHolder.enabled = true;
        }



        /// <summary>
        /// Disables player first person interact behaviour.
        /// </summary>
        public static void DisableFirstPersonInteract()
        {
            instance.firstPersonInteractEnvironment.enabled = false;
        }



        /// <summary>
        /// Enables player first person interact behaviour.
        /// </summary>
        public static void EnableFirstPersonInteract()
        {
            instance.firstPersonInteractEnvironment.enabled = true;
        }



        /// <summary>
        /// Enters item inspection mode.
        /// </summary>
        public static void EnterInspectMode()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                DisablePlayerMovement();
                DisablePlayerItemHolder();
                DisableFirstPersonInteract();
            }

            else if (instance.currentGameState == GameState.PointAndClick)
            {

            }
        }



        /// <summary>
        /// Exits item inspection mode.
        /// </summary>
        public static void ExitInspectMode()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                EnablePlayerMovement();
                EnablePlayerItemHolder();
                EnableFirstPersonInteract();
            }

            else if (instance.currentGameState == GameState.PointAndClick)
            {

            }
        }



        /// <summary>
        /// Enters dialogue mode.
        /// </summary>
        public static void EnterDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                DisablePlayerItemHolder();
                DisablePlayerMovement();
                DisableFirstPersonInteract();

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }



        /// <summary>
        /// Exits dialogue mode.
        /// </summary>
        public static void ExitDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                EnablePlayerItemHolder();
                EnablePlayerMovement();
                EnableFirstPersonInteract();

                instance.playerItemHolder.Refresh();

                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }



        /// <summary>
        /// Enables free roam related components.
        /// </summary>
        private void EnableFreeRoamState()
        {

        }


        
        /// <summary>
        /// Disables free roam related components.
        /// </summary>
        private void DisableFreeRoamState()
        {
            
        }



        /// <summary>
        /// Enables point and click related components.
        /// </summary>
        private void EnablePointAndClickState()
        {
            
        }



        /// <summary>
        /// Disables point and click related components.
        /// </summary>
        private void DisablePointAndClickState()
        {

        }
        #endregion
    }
}