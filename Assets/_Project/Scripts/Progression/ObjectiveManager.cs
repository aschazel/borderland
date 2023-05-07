using UnityEngine;
using ProjectBorderland.DeveloperTools.PublishSubscribe;

namespace ProjectBorderland.Progression
{
    /// <summary>
    /// Handles objective progressions.
    /// </summary>
    public class ObjectiveManager : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        #region singletonDDOL
        private static ObjectiveManager instance;
        public static ObjectiveManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<ObjectiveManager>();

                    if (instance == null)
                    {
                        GameObject newGameObject = new GameObject();
                        newGameObject.name = typeof(ObjectiveManager).Name;
                        instance = newGameObject.AddComponent<ObjectiveManager>();
                    }
                }

                return instance;
            }
        }
        #endregion

        private Objective currentObjective;
        public Objective CurrentObjective { get { return currentObjective; } }



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
        /// Starts an objective.
        /// </summary>
        /// <param name="objective"></param>
        public static void StartObjective(Objective objective)
        {
            instance.currentObjective = objective;
            PublishSubscribe.Instance.Publish<ObjectiveStartedMessage>(new ObjectiveStartedMessage(objective));
        }
        #endregion
    }

    #region PublishSubscribe
    public struct ObjectiveStartedMessage
    {
        public Objective objective;

        public ObjectiveStartedMessage(Objective objective)
        {
            this.objective = objective;
        }
    }
    #endregion
}