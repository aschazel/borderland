using System.Collections;
using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Core.FreeRoam;
using ProjectBorderland.UI.Fade;

namespace ProjectBorderland.UI.Inventory
{
    /// <summary>
    /// Handles item text behaviour.
    /// </summary>
    public class ItemText : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private TextMeshProUGUI textMeshProUGUI;
        private Coroutine fadeCoroutine;
        private bool isShowingText;

        [Header("Attribute Configurations")]
        [SerializeField] private float textShowTime = 2f;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            textMeshProUGUI = GetComponent<TextMeshProUGUI>();
            textMeshProUGUI.alpha = 0f;
            PublishSubscribe.Instance.Subscribe<OnEquipItemMessage>(ShowItemText);
            PublishSubscribe.Instance.Subscribe<EquippedChangedMessage>(HideText);
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<OnEquipItemMessage>(ShowItemText);
            PublishSubscribe.Instance.Unsubscribe<EquippedChangedMessage>(HideText);
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Shows item text.
        /// </summary>
        /// <param name="message"></param>
        private void ShowItemText(OnEquipItemMessage message)
        {
            textMeshProUGUI.text = message.Item.name;

            if(!isShowingText) 
            {
                fadeCoroutine = StartCoroutine(FadeInFadeOut());
            } 

            else 
            {
                StopCoroutine(fadeCoroutine);
                fadeCoroutine = StartCoroutine(FadeInFadeOut());
            }
        }



        /// <summary>
        /// Hides text instaneously.
        /// </summary>
        private void HideText(EquippedChangedMessage message)
        {
            if (isShowingText)
            {
                StopCoroutine(fadeCoroutine);
                FadeAnimation.TextAlphaZero(textMeshProUGUI);
                isShowingText = false;
            }
        }



        /// <summary>
        /// Fades in text and briefly fades out.
        /// </summary>
        /// <returns></returns>
        private IEnumerator FadeInFadeOut()
        {
            isShowingText = true;
            StartCoroutine(FadeAnimation.FadeInText(textMeshProUGUI, 2f));
            yield return new WaitForSecondsRealtime(textShowTime);
            StartCoroutine(FadeAnimation.FadeOutText(textMeshProUGUI, 2f));
            isShowingText = false;
        }
        #endregion
    }
}