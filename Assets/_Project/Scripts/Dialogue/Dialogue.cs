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
        [SerializeField] private string interactUIText;
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
        public string InteractUIText
        {
            get { return interactUIText; }
            set { interactUIText = value; }
        }



        public virtual void Interact()
        {
            DisplayDialogue();
        }



        public virtual void Interact(GameObject _object)
        {}
        #endregion
        #endregion
    }
}