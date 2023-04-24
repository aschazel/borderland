using UnityEngine;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Dialogue
{
    /// <summary>
    /// Handles dialogue interaction.
    /// </summary>
    public class Dialogue : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public DialogueSO DialogueSO;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Displays dialogue window.
        /// </summary>
        public virtual void DisplayDialogue()
        {
            DialogueWindowController.Display(DialogueSO);
        }



        #region IInteractable
        public void Interact()
        {
            DisplayDialogue();
        }



        public void Interact(GameObject _object)
        {}
        #endregion
        #endregion
    }
}