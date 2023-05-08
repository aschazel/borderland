using System.Collections;
using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Progression;

namespace ProjectBorderland.Gameplay.ACT1.Dialogue
{
    /// <summary>
    /// Rotates object to always face main camera.
    /// </summary>
    public class FirstEncounter : Objective
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            StartCoroutine(InitiateDialogue());
            StartObjective();
        }
        #endregion



        #region ProjectBorderland methods
        private IEnumerator InitiateDialogue()
        {
            yield return new WaitForSecondsRealtime(2f);
            DialogueWindowController.Display(dialogue);
        }
        #endregion
    }
}