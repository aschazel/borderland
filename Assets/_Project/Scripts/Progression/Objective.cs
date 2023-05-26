using System;
using UnityEngine;

namespace ProjectBorderland.Progression
{
    /// <summary>
    /// Represents an objective.
    /// </summary>
    public class Objective : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isInitiated;
        public bool IsInitiated { get { return isInitiated; } }
        private bool isCompleted;
        public bool IsCompleted { get { return isCompleted; } }

        [Header("Attribute Configurations")]
        [SerializeField] [TextArea(0, 19)] private string title;
        public string Title { get { return title; } }
        [SerializeField] [TextArea(0, 128)] private string description;
        public string Description { get { return description; } }



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Start()
        {
            ReturnObjectiveState();
        }



        private void Update()
        {
            DisableWhenComplete();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Marks objective as done.
        /// </summary>
        public void StartObjective()
        {
            isInitiated = true;
            gameObject.SetActive(true);
            ObjectiveManager.StartObjective(this);
        }



        /// <summary>
        /// Mark this as complete.
        /// </summary>
        public void MarkAsComplete()
        {
            isCompleted = true;
        }



        /// <summary>
        /// Disables this GameObject when completed.
        /// </summary>
        private void DisableWhenComplete()
        {
            if (isCompleted)
            {
                gameObject.SetActive(false);
            }
        }



        /// <summary>
        /// Gets saved objective states from ObjectiveManager.
        /// </summary>
        private void ReturnObjectiveState()
        {
            Objective savedObjective = ObjectiveManager.Objectives.Find(obj => this);

            if (savedObjective != null)
            {
                isCompleted = savedObjective.IsCompleted;
                isInitiated = savedObjective.IsInitiated;
                title = savedObjective.Title;
                description = savedObjective.Description;
            }
        }
        #endregion
    }
}