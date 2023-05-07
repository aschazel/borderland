using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectBorderland.UI.Fade
{
    /// <summary>
    /// Handles player inventory.
    /// </summary>
    public class FadeAnimation : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static FadeAnimation instance;
        public static FadeAnimation Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<FadeAnimation>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(FadeAnimation).Name;
                        instance = newGameObject.AddComponent<FadeAnimation>();
                    }
                }

                return instance;
            }
        }
        #endregion
        


        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            #region singletonDDOL
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Fades in image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fadeTime"></param>
        public static IEnumerator FadeInImage(Image image, float fadeTime)
        {
            Color imageColor = image.color;

            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, 0f);

            while (image.color.a < 1f)
            {
                float fadeAmount = image.color.a + (fadeTime * Time.unscaledDeltaTime);

                imageColor.a = fadeAmount;
                image.color = imageColor;

                yield return null;
            }
        }



        /// <summary>
        /// Fades in image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fadeTime"></param>
        public static IEnumerator FadeInText(TextMeshProUGUI textMeshProUGUI, float fadeTime)
        {
            Color textColor = textMeshProUGUI.color;

            textMeshProUGUI.color = new Color(textColor.r, textColor.g, textColor.b, 0f);

            while (textMeshProUGUI.color.a < 1f)
            {
                float fadeAmount = textMeshProUGUI.color.a + (fadeTime * Time.unscaledDeltaTime);

                textColor.a = fadeAmount;
                textMeshProUGUI.color = textColor;

                yield return null;
            }
        }



        /// <summary>
        /// Fades out image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fadeTime"></param>
        public static IEnumerator FadeOutImage(Image image, float fadeTime)
        {
            Color imageColor = image.color;

            image.color = new Color(imageColor.r, imageColor.g, imageColor.b, 1f);

            while (image.color.a > 0f)
            {
                float fadeAmount = image.color.a - (fadeTime * Time.unscaledDeltaTime);

                imageColor.a = fadeAmount;
                image.color = imageColor;

                yield return null;
            }
        }



        /// <summary>
        /// Fades out image.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fadeTime"></param>
        public static IEnumerator FadeOutText(TextMeshProUGUI textMeshProUGUI, float fadeTime)
        {
            Color textColor = textMeshProUGUI.color;

            textMeshProUGUI.color = new Color(textColor.r, textColor.g, textColor.b, 1f);

            while (textMeshProUGUI.color.a > 0f)
            {
                float fadeAmount = textMeshProUGUI.color.a - (fadeTime * Time.unscaledDeltaTime);

                textColor.a = fadeAmount;
                textMeshProUGUI.color = textColor;

                yield return null;
            }
        }



        /// <summary>
        /// Sets text alpha to zero.
        /// </summary>
        /// <param name="textMeshProUGUI"></param>
        public static void TextAlphaZero(TextMeshProUGUI textMeshProUGUI)
        {
            Color textColor = textMeshProUGUI.color;

            textMeshProUGUI.color = new Color(textColor.r, textColor.g, textColor.b, 0f);
        }
        #endregion
    }
}