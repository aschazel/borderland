using UnityEngine;

namespace ProjectBorderland.UI.Dialogue
{
    /// <summary>
    /// Handles dialogue navigation behaviour.
    /// </summary>
    public class DialogueNavigationController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private DialogueWindowController dialogueWindowController;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            dialogueWindowController = GetComponentInChildren<DialogueWindowController>();
        }



        private void Update()
        {
            GetInput();
        }



        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                dialogueWindowController.NextSentence();
            }
        }
        #endregion
    }
}