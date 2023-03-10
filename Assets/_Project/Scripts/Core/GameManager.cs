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

        [Header("Object References")]
        [SerializeField] private GameObject playerObject;
        [SerializeField] private GameObject mainCamera;



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
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Switchs game state to specified.
        /// </summary>
        /// <param name="gameState"></param>
        public static void SwitchGameState(GameState gameState)
        {

        }



        /// <summary>
        /// Freezes first person movement and camera movement.
        /// </summary>
        public static void FreezePlayer()
        {
            instance.playerMovement.enabled = false;
            instance.playerCamera.enabled = false;
        }



        /// <summary>
        /// Undo freezes first person movement and camera movement.
        /// </summary>
        public static void UndoFreezePlayer()
        {
            instance.playerMovement.enabled = true;
            instance.playerCamera.enabled = true;
        }



        /// <summary>
        /// Hides player first person item holder.
        /// </summary>
        public static void HidePlayerItemHolder()
        {
            instance.playerItemHolder.enabled = false;
        }



        /// <summary>
        /// Undo hides player first person item holder.
        /// </summary>
        public static void UndoHidePlayerItemHolder()
        {
            instance.playerItemHolder.enabled = true;
        }



        /// <summary>
        /// Enables free roam related components.
        /// </summary>
        private void EnableFreeRoam()
        {

        }


        
        /// <summary>
        /// Disables free roam related components.
        /// </summary>
        private void DisableFreeRoam()
        {
            
        }



        /// <summary>
        /// Enables point and click related components.
        /// </summary>
        private void EnablePointAndClick()
        {
            
        }



        /// <summary>
        /// Disables point and click related components.
        /// </summary>
        private void DisablePointAndClick()
        {

        }
        #endregion
    }
}