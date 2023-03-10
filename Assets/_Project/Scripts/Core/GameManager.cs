using UnityEngine;

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
        /// Enable free roam related components.
        /// </summary>
        private void EnableFreeRoam()
        {

        }


        
        /// <summary>
        /// Disable free roam related components.
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



        /// <summary>
        /// Freeze first person movement.
        /// </summary>
        private void FreezeMovement()
        {

        }
        #endregion
    }
}