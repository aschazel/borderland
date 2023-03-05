using System;
using System.Linq;
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

        [Header("Object References")]
        [SerializeField] public ItemHolder PlayerItemHolder;
        
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
            items = Enumerable.Repeat(CreateNullItem(), maxCapacity).ToList();
        }



        private void Update()
        {
            GetInput();
        }



        private void FixedUpdate()
        {
            SetDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Creates null item for empty reference.
        /// </summary>
        private ItemSO CreateNullItem()
        {
            ItemSO nullItem = ScriptableObject.CreateInstance<ItemSO>();
            nullItem.IsNullItem = true;

            return nullItem;
        }



        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                IncrementEquippedIndex();
            }

            else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                DecrementEquippedIndex();
            }
        }



        /// <summary>
        /// Increments the equipped item slot index.
        /// </summary>
        private void IncrementEquippedIndex()
        {
            if (EquippedSlotIndex < maxCapacity - 1)
            {
                EquippedSlotIndex++;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Decrements the equipped item slot index.
        /// </summary>
        private void DecrementEquippedIndex()
        {
            if (EquippedSlotIndex > 0)
            {
                EquippedSlotIndex--;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Adds an item to inventory by index and returns true if success.
        /// </summary>
        /// <param name="item"></param>
        public static bool Add(ItemSO item, int index)
        {
            if (InventoryManager.Items[index].IsNullItem)
            {
                items[index] = item;
                NotifyOnInventoryChanged();
                return true;
            }

            else if (GetEmptySlot() != -1)
            {
                items[GetEmptySlot()] = item;
                NotifyOnInventoryChanged();
                return true;
            }

            else
            {
                return false;
            }
        }



        /// <summary>
        /// Shorthand for Add() to current slot index.
        /// </summary>
        /// <param name="item"></param>
        public static bool AddCurrentIndex(ItemSO item)
        {
            return Add(item, EquippedSlotIndex);
        }



        /// <summary>
        /// Remove an item from inventory by index.
        /// </summary>
        /// <param name="item"></param>
        public static void Remove(int index)
        {
            ItemSO nullItem = instance.CreateNullItem();
            items[index] = nullItem;
            NotifyOnInventoryChanged();
        }



        /// <summary>
        /// Shorthand for Remove()) to current slot index.
        /// </summary>
        /// <param name="item"></param>
        public static void RemoveCurrentIndex()
        {
            Remove(EquippedSlotIndex);
        }



        /// <summary>
        /// Gets first empty item slot index and returns -1 if inventory is full.
        /// </summary>
        public static int GetEmptySlot()
        {
            int index = 0;
            foreach (ItemSO item in items)
            {
                if (item.IsNullItem)
                {
                    return index;
                }

                index++;
            }

            return -1;
        }



        /// <summary>
        /// Get sprite from item.
        /// </summary>
        /// <param name="index"></param>
        public static Sprite GetSprite(int index)
        {
            if (!items[index].IsNullItem)
            {
                return items[index].Sprite;
            }

            else
            {
                return null;
            }
        }



        /// <summary>
        /// Get model object from item.
        /// </summary>
        /// <param name="index"></param>
        public static GameObject GetModelObject(int index)
        {
            if (!items[index].IsNullItem)
            {
                return items[index].ModelObject;
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