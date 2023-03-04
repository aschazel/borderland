using UnityEngine;

namespace ProjectBorderland.Interactable
{
    /// <summary>
    /// Handles interactable item behaviour.
    /// </summary>
    public class InteractableItem : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private GiveItemBehaviour giveItemBehaviour;

        [Header("Object References")]
        [SerializeField] private string dialog;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            giveItemBehaviour = GetComponent<GiveItemBehaviour>();
        }
        #endregion

        
        
        #region ProjectBorderland methods
        /// <summary>
        /// Interacts with this item.
        /// </summary>
        public void Interact()
        {
            if (giveItemBehaviour != null)
            {
                giveItemBehaviour.Give();
            }
        }
        #endregion
    }
}