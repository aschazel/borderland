using System;
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
        public Action OnItemInteract;

        [Header("Object References")]
        [SerializeField] private string dialog;

        [Header("Attribute Configurations")]
        [SerializeField] private bool isOneTimeInteract;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
         #region ProjectBorderland methods
        /// <summary>
        /// Interacts with this item.
        /// </summary>
        public void Interact()
        {
            NotifyOnInteract();

            if (isOneTimeInteract)
            {
                DestroyAfterInteract();
            }
        }



        #region observer
        /// <summary>
        /// Destroys this object after interaction.
        /// </summary>
        private void DestroyAfterInteract()
        {
            Destroy(gameObject);
        }



        /// <summary>
        /// Notifies when item interacted.
        /// </summary>
        private void NotifyOnInteract()
        {
            OnItemInteract?.Invoke();
        }
        #endregion
        #endregion
    }
}