using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
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
        [SerializeField] private TextMeshProUGUI objectiveDescription;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            PublishSubscribe.Instance.Subscribe<ObjectiveStartedMessage>(UpdateText);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<ObjectiveStartedMessage>(UpdateText);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates the objective title and description text.
        /// </summary>
        private void UpdateText(ObjectiveStartedMessage message)
        {
            objectiveDescription.text = message.objective.Description;
        }
        #endregion
    }
}