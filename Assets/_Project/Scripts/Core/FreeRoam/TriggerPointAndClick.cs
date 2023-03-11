using UnityEngine;
using UnityEngine.SceneManagement;
using ProjectBorderland.Core.PointAndClick;

namespace ProjectBorderland.Core.FreeRoam
{
    /// <summary>
    /// Handles trigger to enter point and click game state.
    /// </summary>
    public class TriggerPointAndClick : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private SceneDataSO sceneData;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(sceneData.SceneName);
            }
        }
        #endregion
    }
}