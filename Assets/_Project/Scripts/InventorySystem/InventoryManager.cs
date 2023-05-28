using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.Core.Manager;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

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

        public static Action OnEquippedChanged;
        private static int slotIndex;
        public static int SlotIndex { get { return slotIndex; } }
        private static List<ItemSO> items = new List<ItemSO>();
        public static List<ItemSO> Items { get { return items; } }
        
        [Header("Attribute Configurations")]
        [SerializeField] private int maxCapacity = 6;
        


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

            items = Enumerable.Repeat(CreateNullItem(), maxCapacity).ToList();
        }



        private void Update()
        {
            GetInput();
        }
        #endregion



        #region ProjectBorderland methods
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

            if (Input.GetKeyDown(InputController.Instance.Slot0))
            {
                slotIndex = 0;
                NotifyOnEquippedChanged();
            }

            if (Input.GetKeyDown(InputController.Instance.Slot1))
            {
                slotIndex = 1;
                NotifyOnEquippedChanged();
            }

            if (Input.GetKeyDown(InputController.Instance.Slot2))
            {
                slotIndex = 2;
                NotifyOnEquippedChanged();
            }

            if (Input.GetKeyDown(InputController.Instance.Slot3))
            {
                slotIndex = 3;
                NotifyOnEquippedChanged();
            }

            if (Input.GetKeyDown(InputController.Instance.Slot4))
            {
                slotIndex = 4;
                NotifyOnEquippedChanged();
            }
            
            if (Input.GetKeyDown(InputController.Instance.Slot5))
            {
                slotIndex = 5;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Increments the equipped item slot index.
        /// </summary>
        private void IncrementEquippedIndex()
        {
            if (slotIndex < maxCapacity - 1)
            {
                slotIndex++;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Decrements the equipped item slot index.
        /// </summary>
        private void DecrementEquippedIndex()
        {
            if (slotIndex > 0)
            {
                slotIndex--;
                NotifyOnEquippedChanged();
            }
        }



        /// <summary>
        /// Creates null item for empty item reference.
        /// </summary>
        private ItemSO CreateNullItem()
        {
            ItemSO nullItem = ScriptableObject.CreateInstance<ItemSO>();
            nullItem.IsNullItem = true;

            return nullItem;
        }



        /// <summary>
        /// Tries to add an item to inventory by index, if occupied then tries to the next slot and returns true if success.
        /// </summary>
        /// <param name="item"></param>
        public static bool Add(ItemSO item, int index)
        {
            if (InventoryManager.Items[index].IsNullItem)
            {
                items[index] = item;
                PublishSubscribe.Instance.Publish<InventoryChangedMessage>(new InventoryChangedMessage(index, item));
                instance.NotifyOnEquippedChanged();

                return true;
            }

            else if (GetEmptySlot() != -1)
            {
                int emptySlotIndex = GetEmptySlot();
                items[emptySlotIndex] = item;
                PublishSubscribe.Instance.Publish<InventoryChangedMessage>(new InventoryChangedMessage(emptySlotIndex, item));
                instance.NotifyOnEquippedChanged();

                return true;
            }

            else
            {
                return false;
            }
        }



        /// <summary>
        /// Remove an item from inventory by index.
        /// </summary>
        /// <param name="item"></param>
        public static void Remove(int index)
        {
            ItemSO nullItem = instance.CreateNullItem();
            items[index] = nullItem;

            PublishSubscribe.Instance.Publish<InventoryChangedMessage>(new InventoryChangedMessage(index, nullItem));
            instance.NotifyOnEquippedChanged();
        }



        /// <summary>
        /// Get currently equipped item.
        /// </summary>
        public static ItemSO GetCurrentIndex()
        {
            return items[slotIndex];
        }



        /// <summary>
        /// Shorthand for Add() to current slot index.
        /// </summary>
        /// <param name="item"></param>
        public static bool AddCurrentIndex(ItemSO item)
        {
            return Add(item, slotIndex);
        }



        /// <summary>
        /// Shorthand for Remove()) to current slot index.
        /// </summary>
        /// <param name="item"></param>
        public static void RemoveCurrentIndex()
        {
            Remove(slotIndex);
        }



        /// <summary>
        /// Gets first empty slot index and returns -1 if no empty slot is found.
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
        public static Sprite GetItemSprite(int index)
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
        /// Get item prefab from item.
        /// </summary>
        /// <param name="index"></param>
        public static GameObject GetItemPrefab(int index)
        {
            if (!items[index].IsNullItem)
            {
                return items[index].Prefab;
            }

            else
            {
                return null;
            }
        }
        #region Observer
        /// <summary>
        /// Notifies when equipped slot is changed.
        /// </summary>
        private void NotifyOnEquippedChanged()
        {
            PublishSubscribe.Instance.Publish<EquippedChangedMessage>(new EquippedChangedMessage(slotIndex));
            OnEquippedChanged?.Invoke();
        }
        #endregion
        #endregion
    }



    #region PublishSubscribe
    public struct InventoryChangedMessage
    {
        public int SlotIndex;
        public ItemSO Item;

        public InventoryChangedMessage(int slotIndex, ItemSO item)
        {
            this.SlotIndex = slotIndex;
            this.Item = item;
        }
    }



    public struct EquippedChangedMessage
    {
        public int SlotIndex;

        public EquippedChangedMessage(int slotIndex)
        {
            this.SlotIndex = slotIndex;
        }
    }
    #endregion
}