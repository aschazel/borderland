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
        public static Action OnEquippedChanged;
        public static int EquippedSlotIndex = 0;
        private static List<ItemSO> items = new List<ItemSO>();
        public static List<ItemSO> Items { get { return items; } }
        private TextMeshProUGUI debugText;
        
        [Header("Attribute Configurations")]
        [SerializeField] private int maxCapacity = 8;
        


        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            #region singletonDDOL
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            #endregion

            debugText = DebugController.Instance.DebugText.transform.Find("InventoryManager").GetComponent<TextMeshProUGUI>();
        }



        private void Update()
        {
            ScrollInventory();
        }



        private void FixedUpdate()
        {
            SetDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Scrolls throughout inventory with mouse scroll wheel.
        /// </summary>
        private void ScrollInventory()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f && EquippedSlotIndex < maxCapacity - 1)
            {
                EquippedSlotIndex++;
                NotifyOnEquippedChanged();
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0f && EquippedSlotIndex > 0)
            {
                EquippedSlotIndex--;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Adds an item to inventory.
        /// </summary>
        /// <param name="item"></param>
        public static void Add(ItemSO item)
        {
            if (items.Count < instance.maxCapacity)
            {
                items.Add(item);
            }

            NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Remove an item from inventory.
        /// </summary>
        /// <param name="item"></param>
        public static void Remove(ItemSO item)
        {
            items.Remove(item);
            NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Remove an item from inventory by index.
        /// </summary>
        /// <param name="item"></param>
        public static void RemoveAtIndex(int index)
        {
            items.RemoveAt(index);
            NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Removes an item in inventory by index and add a new one.
        /// </summary>
        public static void SwapItem(int index, ItemSO newItem)
        {
            RemoveAtIndex(index);
            Add(newItem);
            NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Get sprite from item.
        /// </summary>
        /// <param name="index"></param>
        public static Sprite GetSprite(int index)
        {
            if (index < items.Count)
            {
                return items[index].sprite;
            }

            else
            {
                return null;
            }
        }



        /// <summary>
        /// Get model from item.
        /// </summary>
        /// <param name="index"></param>
        public static GameObject GetModel(int index)
        {
            if (index < items.Count)
            {
                return items[index].model;
            }

            else
            {
                return null;
            }
        }



        #region observer
        /// <summary>
        /// Notifies when inventory changed.
        /// </summary>
        private static void NotifyOnInventoryChanged()
        {
            OnInventoryChanged?.Invoke();
            NotifyOnEquippedChanged();
        }



        /// <summary>
        /// Notifies when item equipped changed.
        /// </summary>
        private static void NotifyOnEquippedChanged()
        {
            OnEquippedChanged?.Invoke();
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

                text += " }\n";
                text += $"Equipped slot index: {EquippedSlotIndex}\n";

                try
                {
                    text += $"Equipped: \"{items[EquippedSlotIndex].name}\"";
                }
                
                catch (ArgumentOutOfRangeException)
                {
                    text += $"Equipped: \"None\"";
                }
                
                debugText.SetText(text);
            }
        }
        #endregion
    }
}