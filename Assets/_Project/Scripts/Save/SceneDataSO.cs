using UnityEngine;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Save
{
    [CreateAssetMenu(menuName = "SceneData/Create new Scene Data")]
    /// <summary>
    /// Represents a scene with its properties.
    /// </summary>
    public class SceneDataSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public int SceneIndex;
        public Vector3 PlayerSpawnLocation;
        public GameState GameState;



        //==============================================================================
        // Functions
        //==============================================================================
    }
}