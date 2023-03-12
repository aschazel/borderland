using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;

namespace ProjectBorderland.Interactable
{
    /// <summary>
    /// Handles dialogue after interaction behaviour.
    /// </summary>
    public class InteractionDialogue : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private InteractableItem interactableItem;
        
        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        private void Awake()
        {
            interactableItem = GetComponent<InteractableItem>();
        }


        
        private void OnEnable()
        {
            interactableItem.OnItemInteract += DisplayDialogue;
        }



        private void OnDisable()
        {
            interactableItem.OnItemInteract -= DisplayDialogue;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Displays dialogue window.
        /// </summary>
        private void DisplayDialogue()
        {
            DialogueWindowController.Display(dialogue);
        }
        #endregion
    }
}