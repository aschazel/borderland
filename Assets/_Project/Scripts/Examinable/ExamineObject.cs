using System;
using UnityEngine;
using ProjectBorderland.Core.PointAndClick;
using ProjectBorderland.Interactable;

namespace ProjectBorderland.Core.Examinable
{
    /// <summary>
    /// Handles player examine object behaviour.
    /// </summary>
    public class ExamineObject : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public Action OnExamineObject;
        private InteractableItem interactableItem;

        [Header("Object References")]
        [SerializeField] CameraBoundary cameraBoundary;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            interactableItem = GetComponent<InteractableItem>();
        }


        
        private void OnEnable()
        {
            interactableItem.OnItemInteract += Examine;
        }



        private void OnDisable()
        {
            interactableItem.OnItemInteract -= Examine;
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Changes game state to point and click and begins to examine object.
        /// </summary>
        private void Examine()
        {
            NotifyOnExamine();
            
            GameManager.SwitchGameState(GameState.PointAndClick);
            GameManager.SetUpPointAndClickCamera(cameraBoundary);
        }



        #region observer
        /// <summary>
        /// Notifies when object examined.
        /// </summary>
        private void NotifyOnExamine()
        {
            OnExamineObject?.Invoke();
        }
        #endregion
        #endregion
    }
}