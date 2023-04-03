using UnityEngine;
using ProjectBorderland.Core.PointAndClick;

namespace ProjectBorderland.Core.Puzzle
{
    /// <summary>
    /// Handles suitcase puzzle lock behaviour.
    /// </summary>
    public class SuitcaseLid : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Animator animator;

        [Header("Attribute Configurations")]
        [SerializeField] private ClickableObject clickable;
        [SerializeField] private SuitcaseLock[] locks;

        

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
            clickable.OnObjectClicked += CheckLock;
        }



        private void OnDisable()
        {
            clickable.OnObjectClicked -= CheckLock;
        }
        #endregion



        #region ProjectBorderland methods
        private void CheckLock()
        {
            foreach (SuitcaseLock suitcaseLock in locks)
            {
                if (!suitcaseLock.IsUnlocked)
                {
                    return;
                }
            }

            OpenLid();        
        }



        private void OpenLid()
        {
            animator.SetTrigger("open");
            Destroy(clickable.gameObject);
        }
        #endregion
    }
}