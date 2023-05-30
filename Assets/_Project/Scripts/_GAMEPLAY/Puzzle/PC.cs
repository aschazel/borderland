using TMPro;
using UnityEngine;

namespace ProjectBorderland.Gameplay.ACT1.Puzzle
{
    /// <summary>
    /// Handles box interactable behaviour.
    /// </summary>
    public class PC : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public bool IsWin;
        [SerializeField] private TMP_InputField passwordField;
        [SerializeField] private GameObject hint;
        [SerializeField] private GameObject desktop;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            //PublishSubscribe.Instance.Subscribe<ObjectiveStartedMessage>(OnObjectiveStarted);
        }



        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return) && passwordField.text == "1995")
            {
                desktop.SetActive(true);
                IsWin = true;
            }

            else if (Input.GetKeyDown(KeyCode.Return) && passwordField.text != "1995")
            {
                hint.gameObject.SetActive(true);
            }

            if (Input.GetKeyDown(KeyCode.Mouse0) && IsWin)
            {
                desktop.SetActive(false);
                gameObject.SetActive(false);
            }
        }



        private void OnDisable()
        {

        }
        #endregion



        #region ProjectBorderland methods
        #endregion
    }
}