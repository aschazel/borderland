using UnityEngine;
using ProjectBorderland.Core.FreeRoam;

namespace ProjectBorderland.Core.Manager
{
    /// <summary>
    /// Handles overall game states.
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

        [Header("Attribute Configurations")]
        [SerializeField] private string freeRoamPlayerTag = "FreeRoamPlayer";

        private GameObject freeRoamPlayer;
        private FreeRoam.PlayerMovement freeRoamPlayerMovement;
        private FreeRoam.PlayerCamera freeRoamPlayerCamera;
        private FreeRoam.Interaction freeRoamInteraction;
        private FreeRoam.PlayerItemHolder freeRoamPlayerItemHolder;

        private GameState currentGameState;

        
        
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

            freeRoamPlayer = GameObject.FindWithTag(freeRoamPlayerTag);

            freeRoamPlayerMovement = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerMovement>();
            freeRoamPlayerCamera = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerCamera>();
            freeRoamInteraction = freeRoamPlayer.GetComponentInChildren<FreeRoam.Interaction>();
            freeRoamPlayerItemHolder = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerItemHolder>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Enters dialogue mode.
        /// </summary>
        public static void EnterDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                instance.freeRoamPlayerMovement.Stop();
                instance.freeRoamPlayerMovement.enabled = false;
                instance.freeRoamPlayerCamera.enabled = false;
                instance.freeRoamInteraction.enabled = false;
                instance.freeRoamPlayerItemHolder.enabled = false;
            }
        }



        /// <summary>
        /// Exits dialogue mode.
        /// </summary>
        public static void ExitDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                instance.freeRoamPlayerMovement.enabled = true;
                instance.freeRoamPlayerCamera.enabled = true;
                instance.freeRoamInteraction.enabled = true;
                instance.freeRoamPlayerItemHolder.enabled = true;
            }
        }



        /// <summary>
        /// Enters inspection mode.
        /// </summary>
        public static void EnterInspection()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                instance.freeRoamPlayerMovement.Stop();
                instance.freeRoamPlayerMovement.enabled = false;
                instance.freeRoamPlayerCamera.enabled = false;
                instance.freeRoamInteraction.enabled = false;
                instance.freeRoamPlayerItemHolder.enabled = false;
            }
        }



        /// <summary>
        /// Exits inspection mode.
        /// </summary>
        public static void ExitInspection()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                instance.freeRoamPlayerMovement.enabled = true;
                instance.freeRoamPlayerCamera.enabled = true;
                instance.freeRoamInteraction.enabled = true;
                instance.freeRoamPlayerItemHolder.enabled = true;
            }
        }
        #endregion
    }
}