using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Gameplay.ACT1.Dialogue
{
    /// <summary>
    /// Handles dialogue interaction.
    /// </summary>
    public class Badriah : ProjectBorderland.Dialogue.Dialogue
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isFirstTimeTriggered;
        private bool isCompleted;

        [SerializeField] DialogueSO DialogueSO2;
        [SerializeField] DialogueSO DialogueSO3;



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        public override void DisplayDialogue()
        {
            if (!isFirstTimeTriggered) 
            {
                base.DisplayDialogue();
                isFirstTimeTriggered = true;
            }

            else if (isFirstTimeTriggered && !isCompleted)
            {
                DialogueWindowController.Display(DialogueSO2);
            }

            else DialogueWindowController.Display(DialogueSO3);
        }



        public override void Interact(GameObject _object)
        {
            if (_object.name == "Cube")
            {
                DialogueWindowController.Display(DialogueSO3);
            }
        }
        #endregion
    }
}