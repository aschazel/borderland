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
        [Header("Attribute Configurations")]
        [SerializeField] [TextArea(0, 19)] private string title;
        public string Title { get { return title; } }
        [SerializeField] [TextArea(0, 128)] private string description;
        public string Description { get { return description; } }



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Marks objective as done.
        /// </summary>
        public void StartObjective()
        {
            ObjectiveManager.StartObjective(this);
        }
        #endregion
    }
}