using UnityEngine;
using ProjectBorderland.Core.Manager;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Dialogue
{
    /// <summary>
    /// Change game state when interacted.
    /// </summary>
    public class InteractGameState : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Attribute Configurations")]
        [SerializeField] private GameState gameState;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Changes game state.
        /// </summary>
        public virtual void ChangeGamestate()
        {
            GameManager.SwitchGamestate(gameState);
        }



        #region IInteractable
        public void Interact()
        {
            ChangeGamestate();
        }



        public void Interact(GameObject _object)
        {}
        #endregion
        #endregion
    }
}