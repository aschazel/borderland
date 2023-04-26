using System.Collections;
using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;
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
        }



        private void OnDisable()
        {
            PublishSubscribe.Instance.Unsubscribe<OnEquipItemMessage>(ShowItemText);
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

            if(fadeCoroutine == null) 
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
        /// Fades in text and briefly fades out.
        /// </summary>
        /// <returns></returns>
        private IEnumerator FadeInFadeOut()
        {
            StartCoroutine(FadeAnimation.FadeInText(textMeshProUGUI, 2f));
            yield return new WaitForSecondsRealtime(textShowTime);
            StartCoroutine(FadeAnimation.FadeOutText(textMeshProUGUI, 2f));
        }
        #endregion
    }
}