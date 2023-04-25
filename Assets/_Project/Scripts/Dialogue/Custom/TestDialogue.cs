using UnityEngine;

namespace ProjectBorderland.Dialogue.Custom
{
    /// <summary>
    /// Test custom dialogue.
    /// </summary>
    public class TestDialogue : Dialogue
    {
        //==============================================================================
        // Variables
        //==============================================================================

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        public override void DisplayDialogue()
        {
            Debug.Log("TESTED");
        }
        #endregion
    }
}