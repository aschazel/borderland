using System.Collections;
using UnityEngine;

namespace ProjectBorderland.Minigame.Showdown
{
    /// <summary>
    /// Handles sentences spawn behaviour.
    /// </summary>
    public class SentenceManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public static SentenceManager Instance;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            Instance = this;
        }
        #endregion



        #region ProjectBorderland methods
        public static void StartShowdown(ShowdownSO showdownData)
        {
            foreach (ShowdownSO.Stage stage in showdownData.Stages)
            {
                
            }
        }



        private IEnumerator ShowSentence(float timeOut, GameObject sentence)
        {
            //Instantiate(GameObject);
            yield return new WaitForSecondsRealtime(timeOut);

        }
        #endregion
    }
}