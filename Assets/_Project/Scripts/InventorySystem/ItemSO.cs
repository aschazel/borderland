using UnityEngine;

namespace ProjectBorderland.InventorySystem
{
    [CreateAssetMenu(menuName = "Items/Create new Item")]
    /// <summary>
    /// Represents an instantiable item.
    /// </summary>
    public class ItemSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public Sprite Sprite;
        public GameObject Prefab;
        [HideInInspector] public bool IsNullItem;



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        /// <summary>
        /// Get model object from item.
        /// </summary>
        public GameObject GetPrefab()
        {
            if (!IsNullItem)
            {
                return Prefab;
            }

            else
            {
                return null;
            }
        }



        /// <summary>
        /// Get sprite from item.
        /// </summary>
        public Sprite GetSprite()
        {
            if (!IsNullItem)
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