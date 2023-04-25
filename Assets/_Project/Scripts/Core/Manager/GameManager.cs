using System.Collections.Generic;
using UnityEngine;

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

        [Header("Object References")]
        [SerializeField] private GameObject freeRoamPlayer;
        [SerializeField] private Camera freeRoamCamera;
        [SerializeField] private GameObject pointAndClickPlayer;
        [SerializeField] private GameObject crosshair;

        private FreeRoam.PlayerMovement freeRoamPlayerMovement;
        private FreeRoam.PlayerCamera freeRoamPlayerCamera;
        private FreeRoam.Interaction freeRoamInteraction;
        private FreeRoam.PlayerItemHolder freeRoamPlayerItemHolder;

        private PointAndClick.Interaction pointAndClickInteraction;

        private GameState currentGameState;
        public List<ActionState> currentActionStates = new List<ActionState>();

        
        
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

            freeRoamPlayerMovement = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerMovement>();
            freeRoamPlayerCamera = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerCamera>();
            freeRoamInteraction = freeRoamPlayer.GetComponentInChildren<FreeRoam.Interaction>();
            freeRoamPlayerItemHolder = freeRoamPlayer.GetComponentInChildren<FreeRoam.PlayerItemHolder>();

            pointAndClickInteraction = pointAndClickPlayer.GetComponentInChildren<PointAndClick.Interaction>();
        }



        private void Start()
        {
            SwitchGamestate(GameState.FreeRoam);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Switches between game states.
        /// </summary>
        /// <param name="gameState"></param>
        public static void SwitchGamestate(GameState gameState)
        {
            if (gameState == GameState.FreeRoam)
            {
                Cursor.lockState = CursorLockMode.Locked;

                instance.pointAndClickInteraction.enabled = false;
            }
        }



        /// <summary>
        /// Checks if current action states contains given action state.
        /// </summary>
        /// <param name="actionState"></param>
        private bool CheckActionState(ActionState actionState)
        {
            return currentActionStates.Contains(actionState);
        }



        /// <summary>
        /// Adds an action state to action states list.
        /// </summary>
        private void AddActionState(ActionState actionState)
        {
            currentActionStates.Add(actionState);
        }



        /// <summary>
        /// Removes an action state from action states list.
        /// </summary>
        private void RemoveActionState(ActionState actionState)
        {
            currentActionStates.Remove(actionState);
        }



        /// <summary>
        /// Enters dialogue mode.
        /// </summary>
        public static void EnterDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                if (!instance.CheckActionState(ActionState.Inspection))
                {
                    Cursor.lockState = CursorLockMode.None;
                    instance.crosshair.SetActive(false);

                    instance.freeRoamPlayerMovement.Stop();
                    instance.freeRoamPlayerMovement.enabled = false;
                    instance.freeRoamPlayerCamera.enabled = false;
                    instance.freeRoamInteraction.enabled = false;
                    instance.freeRoamPlayerItemHolder.enabled = false;
                }

                else
                {
                    instance.pointAndClickInteraction.enabled = false;
                }
            }
        }



        /// <summary>
        /// Exits dialogue mode.
        /// </summary>
        public static void ExitDialogue()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                if (!instance.CheckActionState(ActionState.Inspection))
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    instance.crosshair.SetActive(true);

                    instance.freeRoamPlayerMovement.enabled = true;
                    instance.freeRoamPlayerCamera.enabled = true;
                    instance.freeRoamInteraction.enabled = true;
                    instance.freeRoamPlayerItemHolder.enabled = true;
                }

                else
                {
                    instance.pointAndClickInteraction.enabled = true;
                }
            }
        }



        /// <summary>
        /// Enters inspection mode.
        /// </summary>
        public static void EnterInspection()
        {
            if (instance.currentGameState == GameState.FreeRoam)
            {
                instance.AddActionState(ActionState.Inspection);
                Cursor.lockState = CursorLockMode.None;
                instance.crosshair.SetActive(false);

                instance.pointAndClickInteraction.enabled = true;
                instance.pointAndClickInteraction.PointAndClickCamera = instance.freeRoamCamera;

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
                instance.RemoveActionState(ActionState.Inspection);
                Cursor.lockState = CursorLockMode.Locked;
                instance.crosshair.SetActive(true);

                instance.pointAndClickInteraction.enabled = false;

                instance.freeRoamPlayerMovement.enabled = true;
                instance.freeRoamPlayerCamera.enabled = true;
                instance.freeRoamInteraction.enabled = true;
                instance.freeRoamPlayerItemHolder.enabled = true;
            }
        }
        #endregion
    }
}