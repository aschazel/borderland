using UnityEngine;

namespace ProjectBorderland.Dialogue
{
    /// <summary>
    /// Represents a character.
    /// </summary>
    [CreateAssetMenu(menuName = "Dialogue/Create new Character")]
    public class CharacterSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public Sprite Sprite;



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Get sprite from item.
        /// </summary>
        public Sprite GetSprite()
        {
            if (Sprite != null)
            {
                return Sprite;
            }

            else
            {
                return null;
            }
        }
        #endregion
    }
}