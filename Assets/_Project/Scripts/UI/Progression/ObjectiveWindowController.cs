using TMPro;
using UnityEngine;
using ProjectBorderland.Progression;

namespace ProjectBorderland.UI.Progression
{
    /// <summary>
    /// Handles objective window behaviour.
    /// </summary>
    public class ObjectiveWindowController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private TextMeshProUGUI objectiveTitle;
        [SerializeField] private TextMeshProUGUI objectiveDescription;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            UpdateText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates the objective title and description text.
        /// </summary>
        private void UpdateText()
        {
            try
            {
                objectiveTitle.text = ObjectiveManager.Instance.CurrentObjective.Title;
                objectiveDescription.text = ObjectiveManager.Instance.CurrentObjective.Description;
            }

            catch (System.NullReferenceException)
            {
                
            }
        }
        #endregion
    }
}