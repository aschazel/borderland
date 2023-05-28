using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Progression;
using ProjectBorderland.Interaction;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Gameplay.ACT1.Objectives
{
    /// <summary>
    /// Script for objective 2 in scene Corridor 1F.
    /// </summary>
    public class Objective2CF1 : Objective, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private string interactUIText = "Letakkan kardus (0/4)";
        private int progress;

        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;
        [SerializeField] Objective nextObjective;
        [SerializeField] List<ItemSO> requiredItem = new List<ItemSO>();



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            InitiateDialogue();
        }
        


        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<DialogueCompleteMessage>(OnDialogueEnd);
        }
        #endregion



        #region ProjectBorderland methods
        private void InitiateDialogue()
        {
            DialogueWindowController.Display(dialogue);
            PublishSubscribe.Instance.Subscribe<DialogueCompleteMessage>(OnDialogueEnd);
        }



        private void OnDialogueEnd(DialogueCompleteMessage message)
        {
            if (message.dialogue == dialogue)
            {
                StartObjective();
            }
        }



        /// <summary>
        /// Updates objective progress text.
        /// </summary>
        private void UpdateProgress()
        {
            UpdateDescription($"Angkat kardus-kardus ke depan pintu perpustakaan ({progress}/4)");
            interactUIText = $"Letakkan kardus ({progress}/4)";
        }



        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set {}
        }



        public void Interact()
        {}



        public void Interact(ItemSO item)
        {
            if (requiredItem.Contains(item))
            {
                InventoryManager.RemoveCurrentIndex();
                progress++;
                UpdateProgress();
            }
        }
        #endregion
        #endregion
    }
}