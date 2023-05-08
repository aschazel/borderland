using UnityEngine;
using ProjectBorderland.Interaction;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Gameplay.ACT1.Puzzle
{
    /// <summary>
    /// Handles lock puzzle behaviour.
    /// </summary>
    public class Lock : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private LockNumber lockNumber1;
        [SerializeField] private LockNumber lockNumber2;
        [SerializeField] private LockNumber lockNumber3;
        [SerializeField] private LockNumber lockNumber4;
        [SerializeField] private Transform cameraPosition;

        [Header("Attribute Configurations")]
        [SerializeField] private int passcode1;
        [SerializeField] private int passcode2;
        [SerializeField] private int passcode3;
        [SerializeField] private int passcode4;


        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            CheckPasscode();
        }
        #endregion



        #region ProjectBorderland methods
        private void CheckPasscode()
        {
            if (lockNumber1.CurrentNumber == passcode1
                && lockNumber2.CurrentNumber == passcode2
                && lockNumber3.CurrentNumber == passcode3
                && lockNumber4.CurrentNumber == passcode4
            )
            {
                Debug.Log("COPLETED");
            }
        }



        public void Interact()
        {
            GameManager.SwitchGamestate(GameState.PointAndClick);
            GameManager.SetUpPointAndClickCamera(cameraPosition);
        }



        public void Interact(GameObject _object)
        {}
        #endregion
    }
}