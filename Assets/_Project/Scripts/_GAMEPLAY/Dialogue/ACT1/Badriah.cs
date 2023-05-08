using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;

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

        [SerializeField] DialogueSO DialogueSO2;



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

            else if (isFirstTimeTriggered)
            {
                DialogueWindowController.Display(DialogueSO2);
            }
        }
        #endregion
    }
}