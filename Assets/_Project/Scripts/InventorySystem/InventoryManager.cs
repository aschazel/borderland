using System;
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

        public static Action OnInventoryChanged;
        public int EquippedSlotIndex = 0;
        private List<ItemSO> items = new List<ItemSO>();
        public List<ItemSO> Items { get { return items; } }
        private TextMeshProUGUI debugText;
        
        
        [Header("Attribute Configurations")]
        [SerializeField] private int maxCapacity = 8;
        


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
        public static void Add(ItemSO item)
        {
            if ((instance.items.Count + 1) < instance.maxCapacity)
            {
                instance.items.Add(item);
            }

            instance.NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Remove an item from inventory.
        /// </summary>
        /// <param name="item"></param>
        public static void Remove(ItemSO item)
        {
            instance.items.Remove(item);
            instance.NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Remove an item from inventory by index.
        /// </summary>
        /// <param name="item"></param>
        public static void RemoveAtIndex(int index)
        {
            instance.items.RemoveAt(index);
            instance.NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Removes an item in inventory by index and add a new one.
        /// </summary>
        public static void SwapItem(int index, ItemSO newItem)
        {
            RemoveAtIndex(index);
            Add(newItem);
            instance.NotifyOnInventoryChanged();
        }



        public static Sprite GetSprite(int index)
        {
            return instance.Items[index].Sprite;
        }



        #region observer
        /// <summary>
        /// Notifies when inventory changed.
        /// </summary>
        private void NotifyOnInventoryChanged()
        {
            OnInventoryChanged?.Invoke();
        }
        #endregion
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