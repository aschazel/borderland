using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Progression;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Interaction;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Gameplay.ACT1.Objectives
{
    /// <summary>
    /// Script for objective 2 in scene Corridor 1F.
    /// </summary>
    public class Objective3CF1 : Objective, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;
        [SerializeField] private GameObject person;

        [Header("Attribute Configurations")]
        [SerializeField] private string interactUIText;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
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
                Title = "Pos Layanan Terpadu";
                Description = "Ikuti Bu Meli ke Pos Layanan Terpadu";
                GetComponent<Collider>().enabled = false;
                StartObjective();
                person.gameObject.SetActive(false);
            }
        }



        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set {}
        }



        public void Interact()
        {
            InitiateDialogue();
        }



        public void Interact(ItemSO item)
        {}
        #endregion
        #endregion
    }
}