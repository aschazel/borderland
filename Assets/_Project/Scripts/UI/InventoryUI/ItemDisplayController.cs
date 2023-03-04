using UnityEngine;
using UnityEngine.UI;

namespace ProjectBorderland.UI
{
    /// <summary>
    /// Handles item sprite display behaviour on UI.
    /// </summary>
    public class ItemDisplayController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private Image image;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            image = GetComponent<Image>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates self sprite to a new one.
        /// </summary>
        /// <param name="newImage"></param>
        public void UpdateImage(Sprite newSprite)
        {
            image.sprite = newSprite;
        }
        #endregion
    }
}