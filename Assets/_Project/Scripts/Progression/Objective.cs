using System;
using UnityEngine;

namespace ProjectBorderland.Progression
{
    [Serializable]
    /// <summary>
    /// Represents an objective.
    /// </summary>
    public class Objective : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public bool IsInitiated;
        private bool isCompleted;
        public bool IsCompleted { get { return isCompleted; } }

        [Header("Attribute Configurations")]
        public int Id;
        [SerializeField] [TextArea(0, 19)] private string title;
        public string Title { get { return title; } set {} }
        [SerializeField] [TextArea(0, 128)] private string description;
        public string Description { get { return description; } set {} }
        public Objective nextObjective;



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
            IsInitiated = true;
            gameObject.SetActive(true);
            ObjectiveManager.StartObjective(this);
        }



        /// <summary>
        /// Enables this objective.
        /// </summary>
        public void ActivateObjective()
        {
            gameObject.SetActive(true);
        }



        /// <summary>
        /// Mark this objective as complete.
        /// </summary>
        public void MarkAsComplete()
        {
            isCompleted = true;
        }



        /// <summary>
        /// Updates this objective description.
        /// </summary>
        public void UpdateDescription(string updatedDescription)
        {
            description = updatedDescription;
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
        public bool ReturnObjectiveState()
        {
            try
            {
                Objective savedObjective = ObjectiveManager.Objectives[Id];

                isCompleted = savedObjective.IsCompleted;
                IsInitiated = savedObjective.IsInitiated;
                title = savedObjective.Title;
                description = savedObjective.Description;

                if (isCompleted)
                {
                    nextObjective.gameObject.SetActive(true);
                    nextObjective.IsInitiated = true;
                }
                
                return true;
            }

            catch (ArgumentOutOfRangeException)
            {}

            catch (NullReferenceException)
            {}

            return false;
        }
        #endregion
    }
}