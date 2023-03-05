using TMPro;
using UnityEngine;
using ProjectBorderland.Interactable;
using ProjectBorderland.DeveloperTools;

namespace ProjectBorderland.Core
{
    /// <summary>
    /// Handles interact by crosshair behaviour.
    /// </summary>
    public class FirstPersonInteract : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private TextMeshProUGUI debugText;
        
        [Header("Object References")]
        [SerializeField] private Transform cameraTransform;

        [Header("Attribute Configurations")]
        [SerializeField] private float interactDistance;


        
        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Awake()
        {
            debugText = DebugController.Instance.DebugText.transform.Find("FirstPersonInteract").GetComponent<TextMeshProUGUI>();
        }



        private void Update()
        {
            GetInput();
            Interact();
            SetDebugText();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(InputController.Instance.Interact))
            {
                Interact();
            }
        }



        /// <summary>
        /// Tries to interact with item on sight.
        /// </summary>
        private void Interact()
        {
            InteractableItem item = DetectInteractable();
                
            if (item != null)
            {
                item.Interact();
            }
        }



        /// <summary>
        /// Detects interactable item on sight.
        /// </summary>
        private InteractableItem DetectInteractable()
        {
            RaycastHit hit;
            Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, interactDistance);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject.GetComponent<InteractableItem>() != null)
                {
                    InteractableItem item = hit.collider.gameObject.GetComponent<InteractableItem>();
                    return item;
                }

                return null;
            }

            return null;
        }
        #endregion



        #region Debug
        /// <summary>
        /// Sets debug text.
        /// </summary>
        private void SetDebugText()
        {
            if (DebugController.Instance.IsDebugMode)
            {
                string text;
                InteractableItem item = DetectInteractable();
                string itemName = "";

                if (item != null)
                {
                    itemName = item.name;
                }

                else
                {
                    itemName = "None";
                };

                text = $"Interactable: \"{itemName}\"";

                debugText.SetText(text);
            }
        }
        #endregion
    }
}