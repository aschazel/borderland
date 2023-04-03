using UnityEngine;
using ProjectBorderland.Core.PointAndClick;

namespace ProjectBorderland.Core.Puzzle
{
    /// <summary>
    /// Handles suitcase puzzle lock behaviour.
    /// </summary>
    public class SuitcaseLock : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Animator animator;
        public bool IsUnlocked;

        [Header("Attribute Configurations")]
        [SerializeField] private ClickableObject clickable;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }



        private void OnEnable()
        {
            clickable.OnObjectClicked += OpenLock;
        }



        private void OnDisable()
        {
            clickable.OnObjectClicked -= OpenLock;
        }
        #endregion



        #region ProjectBorderland methods
        private void OpenLock()
        {
            IsUnlocked = true;
            animator.SetTrigger("open");
        }
        #endregion
    }
}