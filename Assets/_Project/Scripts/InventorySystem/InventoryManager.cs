using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ProjectBorderland.DeveloperTools;

namespace ProjectBorderland.InventorySystem
{
    /// <summary>
    /// Handles player inventory.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static InventoryManager instance;
        public static InventoryManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<InventoryManager>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(InventoryManager).Name;
                        instance = newGameObject.AddComponent<InventoryManager>();
                    }
                }

                return instance;
            }
        }
        #endregion

        [SerializeField] private List<ItemSO> items = new List<ItemSO>();
        public List<ItemSO> Items { get { return items; } }
        private TextMeshProUGUI debugText;
        


        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            debugText = DebugController.Instance.DebugText.transform.Find("Inventory").GetComponent<TextMeshProUGUI>();
        }



        private void FixedUpdate()
        {
            SetDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Adds an item to inventory.
        /// </summary>
        /// <param name="item"></param>
        public void Add(ItemSO item)
        {
            items.Add(item);
        }



        /// <summary>
        /// Remove an item from inventory.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(ItemSO item)
        {
            items.Remove(item);
        }
        #endregion



        #region Debug
        /// <summary>
        /// Sets debug text.
        /// </summary>
        private void SetDebugText()
        {
            if (DebugController.Instance.IsDebugMode)
            {
                string text;
                string itemName;

                text = $"Inventory: {{";

                foreach (ItemSO item in items)
                {
                    itemName = item.Name;
                    text += $" \"{itemName}\",";
                }

                text += " }";
                
                debugText.SetText(text);
            }
        }
        #endregion
    }
}