using System.Collections.Generic;
using UnityEngine;

namespace ProjectBorderland.InventorySystem
{
    [CreateAssetMenu(menuName = "Items/Create new Item")]
    /// <summary>
    /// Handles player inventory.
    /// </summary>
    public class ItemSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public int Id;
        public string Name;
        public Sprite Sprite;
    }
}