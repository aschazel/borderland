using UnityEngine;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Represents a scene with its properties.
    /// </summary>
    public class SceneDataSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public string SceneIndex;
        public Vector3 PlayerSpawnLocation;



        //==============================================================================
        // Functions
        //==============================================================================
    }
}