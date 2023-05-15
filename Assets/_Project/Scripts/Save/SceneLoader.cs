using UnityEngine;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Handles initial scene loading.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [SerializeField] private SceneDataSO sceneData;
        [SerializeField] private Vector3 playerSpawnCoordinate;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {

        }
        #endregion



        #region ProjectBorderland methods
        private void SetUpScene()
        {
            
        }
        #endregion
    }
}