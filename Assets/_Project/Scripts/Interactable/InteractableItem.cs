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
        private PickableBehaviour pickableBehaviour;

        [Header("Object References")]
        [SerializeField] private string dialog;

        [Header("Attribute Configurations")]
        [SerializeField] private bool isOneTimeInteract;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            giveItemBehaviour = GetComponent<GiveItemBehaviour>();
            pickableBehaviour = GetComponent<PickableBehaviour>();
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

            if (pickableBehaviour != null)
            {
                pickableBehaviour.PickUp();
            }

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
        #endregion
    }
}