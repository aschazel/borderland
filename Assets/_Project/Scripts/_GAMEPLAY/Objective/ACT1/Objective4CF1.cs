using System;
using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Progression;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
using ProjectBorderland.Gameplay.ACT1.Puzzle;

namespace ProjectBorderland.Gameplay.ACT1.Objectives
{
    /// <summary>
    /// Script for objective 2 in scene Corridor 1F.
    /// </summary>
    public class Objective4CF1 : Objective
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isReady;

        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;
        [SerializeField] private GameObject person;
        [SerializeField] private PC pc;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods

        private void Update()
        {
            CheckPrevious();
            if (isReady && IsInitiated) 
            {
                StartObjective();
                InitiateDialogue();
            }
        }
        


        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<DialogueCompleteMessage>(OnDialogueEnd);
        }
        #endregion



        #region ProjectBorderland methods
        private void CheckPrevious()
        {
            if (ObjectiveManager.Objectives.Count >= Id)
            {
                isReady = true;
            }
        }



        private void CheckPassword()
        {
            if (pc.IsWin)
            {
                MarkAsComplete();
            }
        }



        private void InitiateDialogue()
        {
            person.gameObject.SetActive(true);
            IsInitiated = false;
            DialogueWindowController.Display(dialogue);
            PublishSubscribe.Instance.Subscribe<DialogueCompleteMessage>(OnDialogueEnd);
        }



        private void OnDialogueEnd(DialogueCompleteMessage message)
        {
            if (message.dialogue == dialogue)
            {
                
            }
        }
        #endregion
    }
}