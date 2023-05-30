using System.Collections.Generic;
using UnityEngine;

namespace ProjectBorderland.Minigame.Showdown
{
    [CreateAssetMenu(menuName = "Items/Create new Item")]
    /// <summary>
    /// Represents an instantiable item.
    /// </summary>
    public class ShowdownSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public List<Stage> Stages;

        [System.Serializable]
        public struct Stage
        {
            public List<GameObject> Sentences;
            public float TimeOut;
        }



        //==============================================================================
        // Functions
        //==============================================================================
        #region ProjectBorderland methods
        #endregion
    }
}