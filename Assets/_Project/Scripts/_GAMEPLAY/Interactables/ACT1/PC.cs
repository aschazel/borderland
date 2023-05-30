using UnityEngine;
using UnityEngine.UI;
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
    public class PC : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private string interactUIText = "Kardus";

        [Header("Object References")]
        [SerializeField] private GameObject pcImage;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            //PublishSubscribe.Instance.Subscribe<ObjectiveStartedMessage>(OnObjectiveStarted);
        }



        private void OnDisable()
        {

        }
        #endregion



        #region ProjectBorderland methods
        #region IInteractable
        public string InteractUIText
        {
            get { return interactUIText; }
            set {}
        }



        public virtual void Interact()
        {
            pcImage.gameObject.SetActive(true);
            // if (isReadyToInteract)
            // {
            //     InventoryManager.AddCurrentIndex(givenItem);
                
            //     CascadeBoxes();

            //     gameObject.SetActive(false);
            // }

            // else
            // {
            //     DialogueWindowController.Display(notActivatedDialogue);
            // }
        }



        public void Interact(ItemSO item)
        {}
        #endregion
        #endregion
    }
}