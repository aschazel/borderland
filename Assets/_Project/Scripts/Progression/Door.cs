using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.UI.Dialogue;
using ProjectBorderland.Dialogue;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Progression
{
    /// <summary>
    /// Loads a scene when interacted.
    /// </summary>
    public class Door : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private bool isNotRestricted;
        
        [Header("Attribute Configurations")]
        [SerializeField] private string interactUIText;

        [Header("Object References")]
        [SerializeField] private Objective objectiveToAccess;
        [SerializeField] private DialogueSO restrictedDialogue;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            CheckRestriction();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Checks if this door is restricted from objective completed.
        /// </summary>
        private void CheckRestriction()
        {
            if (ObjectiveManager.Objectives.Contains(objectiveToAccess))
            {
                if (ObjectiveManager.Objectives.Find(objective => objectiveToAccess).IsCompleted)
                {
                    isNotRestricted = false;
                }
            }
        }



        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set {}
        }



        public virtual void Interact()
        {
            if (isNotRestricted)
            {

            }

            else
            {
                DialogueWindowController.Display(restrictedDialogue);
            }
        }



        public void Interact(ItemSO item)
        {}
        #endregion
        #endregion
    }
}