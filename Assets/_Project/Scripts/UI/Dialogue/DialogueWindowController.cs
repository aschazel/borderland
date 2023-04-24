using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ProjectBorderland.Dialogue;
using ProjectBorderland.Core.Manager;

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
        private bool isDialogueActive;
        private bool isReadyToContinue;
        private Coroutine currentlyTyping;
        private DialogueSO dialogue;
        private int currentDialogueIndex;
        private TextMeshProUGUI sentenceText;
        private Image characterImage;
        private TextMeshProUGUI characterName;

        [Header("Object References")]
        [SerializeField] private GameObject shadow;
        [SerializeField] private GameObject background;
        [SerializeField] private GameObject characterImageSlot;
        [SerializeField] private GameObject characterNameSlot;
        [SerializeField] private GameObject text;
        [SerializeField] private GameObject markContinue;

        
        
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
        }



        private void Update()
        {
            GetInput();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && isDialogueActive)
            {
                if (isReadyToContinue) NextSentence();
                if (!isReadyToContinue && currentlyTyping != null) SkipTypingAnimation();
            }
        }



        /// <summary>
        /// Marks dialogue is active.
        /// </summary>
        private IEnumerator MarkDialogueActive()
        {
            yield return 0;
            isDialogueActive = true;
        }



        /// <summary>
        /// Marks current sentence ready to continue.
        /// </summary>
        private void MarkReadyToContinue()
        {
            isReadyToContinue = true;
            markContinue.SetActive(true);
            currentlyTyping = null;
        }



        /// <summary>
        /// Marks current sentence not ready to continue.
        /// </summary>
        private void MarkNotReadyToContinue()
        {
            isReadyToContinue = false;
            markContinue.SetActive(false);
        }



        /// <summary>
        /// Displays dialogue window on screen.
        /// </summary>
        /// <param name="dialogue"></param>
        public static void Display(DialogueSO dialogue)
        {
            GameManager.EnterDialogue();

            instance.background.SetActive(true);
            instance.text.SetActive(true);
            instance.shadow.SetActive(true);

            instance.currentDialogueIndex = 0;
            instance.dialogue = dialogue;

            instance.UpdateText();
            instance.UpdateCharacter();

            instance.StartCoroutine(instance.MarkDialogueActive());
        }



        /// <summary>
        /// Closes dialogue window from screen.
        /// </summary>
        private void Close()
        {
            GameManager.ExitDialogue();

            background.SetActive(false);
            characterImageSlot.SetActive(false);
            characterNameSlot.SetActive(false);
            text.SetActive(false);
            shadow.SetActive(false);

            isDialogueActive = false;
        }



        /// <summary>
        /// Advances to next sentence in dialogue.
        /// </summary>
        public void NextSentence()
        {
            if (currentDialogueIndex < dialogue.Sentences.Count - 1)
            {
                currentDialogueIndex++;

                UpdateCharacter();
                UpdateText();
            }

            else
            {
                Close();
            }

            MarkNotReadyToContinue();
        }



        /// <summary>
        /// Updates sentence text in dialogue window to current sentence.
        /// </summary>
        private void UpdateText()
        {
            string say = dialogue.Sentences[instance.currentDialogueIndex].Say;
            string[] links = ExtractLink(say);
            say = FormatLinkInString(say);
            
            List<char> sayLineCharacters = new List<char>(say.ToCharArray());
            sentenceText.text = string.Empty;
            
            currentlyTyping = StartCoroutine(AnimateTyping(sayLineCharacters, links));
        }



        /// <summary>
        /// Extracts TMP links so it can be passed to typing animation.
        /// </summary>
        private string[] ExtractLink(string input)
        {
            string pattern = @"<link=""([^""]*)"">([^<]*)</link>";

            MatchCollection matches = Regex.Matches(input, pattern);
        
            if (matches.Count > 0)
            {
                string[] linkUrls = new string[matches.Count];

                for (int i = 0; i < matches.Count; i++)
                {
                    string link = matches[i].Value;
                    linkUrls[i] = link;
                }

                return linkUrls;
            }

            else
            {
                return null;
            }
        }



        /// <summary>
        /// Replaces links inside a string into backslashes.
        /// </summary>
        private string FormatLinkInString(string input)
        {
            string pattern = @"<link=""([^""]*)"">([^<]*)</link>";
            
            MatchCollection matches = Regex.Matches(input, pattern);
            
            if (matches.Count > 0)
            {
                string result = Regex.Replace(input, pattern, "\\");
                return result;
            }
            else
            {
                return input;
            }
        }



        /// <summary>
        /// Animates shown up dialogue text.
        /// </summary>
        private IEnumerator AnimateTyping(List<char> characters, string[] links = null)
        {
            int linkIndex = 0;

            foreach(char character in characters)
            {
                if(character == '\\')
                {
                    string linkText = "<color=blue>" + links[linkIndex] + "</color>";
                    sentenceText.text += linkText;
                    linkIndex++;
                }

                else sentenceText.text += character;

                if(sentenceText.text == dialogue.Sentences[instance.currentDialogueIndex].Say)
                {
                    MarkReadyToContinue();
                }

                yield return new WaitForSecondsRealtime(1 * dialogue.Speed);
            }
        }



        /// <summary>
        /// Skips typing animation and instantly set the whole sentence text.
        /// </summary>
        private void SkipTypingAnimation()
        {
            StopCoroutine(currentlyTyping);
            sentenceText.text = dialogue.Sentences[instance.currentDialogueIndex].Say;
            MarkReadyToContinue();
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