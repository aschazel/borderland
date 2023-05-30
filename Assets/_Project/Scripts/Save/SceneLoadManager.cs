using UnityEngine;
using UnityEngine.SceneManagement;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Handles scene and object states loading.
    /// </summary>
    public class SceneLoadManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static SceneLoadManager instance;
        public static SceneLoadManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SceneLoadManager>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(SceneLoadManager).Name;
                        instance = newGameObject.AddComponent<SceneLoadManager>();
                    }
                }

                return instance;
            }
        }
        #endregion



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
        /// Loads given scene and applies last saved object states.
        /// </summary>
        /// <param name="sceneDataSO"></param>
        public static void LoadScene(SceneDataSO sceneDataSO)
        {
            SceneManager.LoadScene(sceneDataSO.SceneIndex);
            PublishSubscribe.Instance.Publish<SceneLoadedMessage>(new SceneLoadedMessage(sceneDataSO));
        }
        #endregion
    }



    public struct SceneLoadedMessage
    {
        public SceneDataSO scene;

        public SceneLoadedMessage(SceneDataSO scene)
        {
            this.scene = scene;
        }
    }
}