using UnityEngine;
using ProjectBorderland.Dialogue;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Progression;
using ProjectBorderland.Interaction;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Gameplay.ACT1.Dialogue
{
    /// <summary>
    /// Script for objective 2 in scene Corridor 1F.
    /// </summary>
    public class Objective1CF1 : Objective, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private DialogueSO dialogue;
        [SerializeField] Objective nextObjective;

        [Header("Attribute Configurations")]
        [SerializeField] private string interactUIText;



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



        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set {}
        }



        public void Interact()
        {
            MarkAsComplete();
            nextObjective.StartObjective();
        }



        public void Interact(GameObject _object)
        {}
        #endregion
        #endregion
    }
}