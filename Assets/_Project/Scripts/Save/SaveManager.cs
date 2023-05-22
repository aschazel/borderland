using UnityEngine;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Manages all saving through the game.
    /// </summary>
    public class SaveManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static SaveManager instance;
        public static SaveManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SaveManager>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(SaveManager).Name;
                        instance = newGameObject.AddComponent<SaveManager>();
                    }
                }

                return instance;
            }
        }
        #endregion

        private SaveData currentSaveData;



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
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Adds a dynamic object to the list.
        /// </summary>
        /// <param name="dynamicObject"></param>
        public static void AddDynamicObject(DynamicObject dynamicObject)
        {
            instance.currentSaveData.DynamicObjects.Add(dynamicObject);
        }



        /// <summary>
        /// Removes a dynamic object from the list.
        /// </summary>
        /// <param name="dynamicObject"></param>
        public static void RemoveDynamicObject(DynamicObject dynamicObject)
        {
            instance.currentSaveData.DynamicObjects.Remove(dynamicObject);
        }



        /// <summary>
        /// Adds a pickable item to the list.
        /// </summary>
        /// <param name="pickableItem"></param>
        public static void AddPickableItem(PickableItem pickableItem)
        {
            instance.currentSaveData.PickableItems.Add(pickableItem);
        }



        /// <summary>
        /// Removes a pickable item from the lst.
        /// </summary>
        /// <param name="pickableItem"></param>
        public static void RemovePickableItem(PickableItem pickableItem)
        {
            instance.currentSaveData.PickableItems.Remove(pickableItem);
        }
        #endregion
    }
}