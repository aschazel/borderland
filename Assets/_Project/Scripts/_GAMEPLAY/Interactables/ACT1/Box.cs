using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
using ProjectBorderland.Interaction;
using ProjectBorderland.Progression;
using ProjectBorderland.Dialogue;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.UI.Dialogue;

namespace ProjectBorderland.Gameplay.ACT1.Interactables
{
    /// <summary>
    /// Handles box interactable behaviour.
    /// </summary>
    public class Box : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isReadyToInteract;
        private string interactUIText = "Kardus";

        [Header("Object References")]
        [SerializeField] private Objective objectiveToActivate;
        [SerializeField] private DialogueSO notActivatedDialogue;
        [SerializeField] private ItemSO givenItem;
        [SerializeField] private List<GameObject> boxesOnTop = new List<GameObject>();



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            isReadyToInteract = false;
            PublishSubscribe.Instance.Subscribe<ObjectiveStartedMessage>(OnObjectiveStarted);
        }



        private void OnDisable()
        {

        }
        #endregion



        #region ProjectBorderland methods
        private void OnObjectiveStarted(ObjectiveStartedMessage message)
        {
            if (message.objective == objectiveToActivate)
            {
                isReadyToInteract = true;
                interactUIText = "Ambil Kardus";
            }
        }



        /// <summary>
        /// Cascades boxes on top of this box.
        /// </summary>
        private void CascadeBoxes()
        {
            if (boxesOnTop.Count > 0)
            {
                foreach (GameObject box in boxesOnTop)
                {
                    box.AddComponent<Rigidbody>();
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
            if (isReadyToInteract)
            {
                InventoryManager.AddCurrentIndex(givenItem);
                
                CascadeBoxes();

                gameObject.SetActive(false);
            }

            else
            {
                DialogueWindowController.Display(notActivatedDialogue);
            }
        }



        public void Interact(ItemSO item)
        {}
        #endregion
        #endregion
    }
}