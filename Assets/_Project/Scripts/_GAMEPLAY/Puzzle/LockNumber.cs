using UnityEngine;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Gameplay.ACT1.Puzzle
{
    /// <summary>
    /// Handles lock number puzzle behaviour.
    /// </summary>
    public class LockNumber : MonoBehaviour, IInteractable
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private int currentNumber = 1;
        public int CurrentNumber { get { return currentNumber; } }
        [SerializeField] private int initialNumber = 1;
        [SerializeField] private int maxNumber = 9;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        public void Interact()
        {
            transform.Rotate(0f, 0f, 36f);
            
            if (currentNumber >= maxNumber)
            {
                currentNumber = initialNumber;
            }

            else currentNumber++;
        }



        public void Interact(GameObject _object)
        {}
        #endregion
    }
}