using System;
using UnityEngine;

namespace ProjectBorderland.Core.PointAndClick
{
    /// <summary>
    /// Handles clickable object behaviour.
    /// </summary>
    public class ClickableObject : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public Action OnItemClicked;

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



        /// <summary>
        /// Destroys this object after interaction.
        /// </summary>
        private void DestroyAfterInteract()
        {
            Destroy(gameObject);
        }



        #region observer
        /// <summary>
        /// Notifies when item interacted.
        /// </summary>
        private void NotifyOnInteract()
        {
            OnItemClicked?.Invoke();
        }
        #endregion
        #endregion
    }
}