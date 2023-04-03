using System.Collections.Generic;
using TMPro;
using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.DeveloperTools
{
    /// <summary>
    /// Handles game debugging.
    /// </summary>
    public class DebugController : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private static DebugController instance;
        public static DebugController Instance { get { return instance; } }

        [Header("Attribute Settings")]
        public bool IsDebugMode;

        [Header("Object Attachments")]
        [SerializeField] private TextMeshProUGUI debugText;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            instance = this;
        }



        private void Update()
        {
            UpdateDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Updates debug texts.
        /// </summary>
        private void UpdateDebugText()
        {

        }
        #endregion
    }
}