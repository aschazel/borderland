using UnityEngine;
using UnityEngine.UI;

namespace ProjectBorderland.UI.Inventory
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



        private void Update()
        {
            HideImage();
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



        /// <summary>
        /// Hide image if item is empty.
        /// </summary>
        private void HideImage()
        {
            if (image.sprite == null)
            {
                image.enabled = false;
            }

            else
            {
                image.enabled = true;
            }
        }
        #endregion
    }
}