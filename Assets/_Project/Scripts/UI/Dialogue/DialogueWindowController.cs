using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ProjectBorderland.Dialogue;
using ProjectBorderland.Core;

namespace ProjectBorderland.UI.Dialogue
{
    /// <summary>
    /// Handles dialogue window behaviour.
    /// </summary>
    public class DialogueWindowController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private static DialogueWindowController instance;
        public static DialogueWindowController Instance { get { return instance; } }
        private DialogueSO dialogue;
        private int currentDialogueIndex;
        private DialogueNavigationController dialogueNavigationController;
        private TextMeshProUGUI sentenceText;
        private Image characterImage;
        private TextMeshProUGUI characterName;

        [Header("Object References")]
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject characterImageSlot;
        [SerializeField] private GameObject characterNameSlot;
        [SerializeField] private GameObject text;

        
        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            instance = this;
            sentenceText = text.GetComponent<TextMeshProUGUI>();
            characterImage = characterImageSlot.GetComponent<Image>();
            characterName = characterNameSlot.GetComponent<TextMeshProUGUI>();
            dialogueNavigationController = GetComponent<DialogueNavigationController>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Displays dialogue window on screen.
        /// </summary>
        /// <param name="dialogue"></param>
        public static void Display(DialogueSO dialogue)
        {
            GameManager.EnterDialogue();

            instance.background.SetActive(true);
            instance.text.SetActive(true);

            instance.currentDialogueIndex = 0;
            instance.dialogue = dialogue;

            instance.UpdateText();
            instance.UpdateCharacter();

            instance.dialogueNavigationController.enabled = true;
        }



        /// <summary>
        /// Undisplays dialogue window from screen.
        /// </summary>
        private void Undisplay()
        {
            GameManager.ExitDialogue();

            background.SetActive(false);
            characterImageSlot.SetActive(false);
            characterNameSlot.SetActive(false);
            text.SetActive(false);

            instance.dialogueNavigationController.enabled = false;
            dialogue = null;
        }



        /// <summary>
        /// Advances to next sentence in dialogue.
        /// </summary>
        public void NextSentence()
        {
            if (currentDialogueIndex < dialogue.Sentences.Count - 1)
            {
                currentDialogueIndex++;

                UpdateText();
                UpdateCharacter();
            }

            else
            {
                Undisplay();
            }
        }



        /// <summary>
        /// Updates sentence text in dialogue window to current sentence.
        /// </summary>
        private void UpdateText()
        {
            string say = dialogue.Sentences[instance.currentDialogueIndex].Say;
            sentenceText.text = say;
        }



        /// <summary>
        /// Updates character image and name in dialogue window to current character author.
        /// </summary>
        private void UpdateCharacter()
        {
            CharacterSO author = dialogue.Sentences[currentDialogueIndex].Author;

            if (author != null)
            {
                characterImageSlot.SetActive(true);
                characterNameSlot.SetActive(true);

                characterImage.sprite = author.Sprite;
                characterName.text = author.Name;
            }

            else
            {
                characterImageSlot.SetActive(false);
                characterNameSlot.SetActive(false);
            }
        }
        #endregion
    }
}