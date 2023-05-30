using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace ProjectBorderland.Minigame.Showdown
{
    /// <summary>
    /// Handles truth bullet behaviour.
    /// </summary>
    public class TruthBullet : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private TextMeshPro truthBulletText;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void OnTriggerEnter(Collider collider)
        {
            StartCoroutine(CutText());
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Cuts text if it collide with something.
        /// </summary>
        private IEnumerator CutText()
        {
            foreach (char character in truthBulletText.text)
            {
                try
                {
                    truthBulletText.text = truthBulletText.text.Substring(2);
                }
                
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }

                yield return null;
            }
        }
        #endregion
    }
}