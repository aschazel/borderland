using UnityEngine;

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
        private SpriteRenderer spriteRenderer;

        

        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates self sprite to a new one.
        /// </summary>
        /// <param name="newSprite"></param>
        public void UpdateSprite(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }
        #endregion
    }
}