using System.Collections.Generic;
using UnityEngine;
using ProjectBorderland.InventorySystem;
using ProjectBorderland.Core.Manager;

namespace ProjectBorderland.Core.Inspection
{
    /// <summary>
    /// Handles item inspection.
    /// </summary>
    public class Inspection : MonoBehaviour
    {
        //==============================================================================
        // Variables
        //==============================================================================
        private bool isInspecting;
        private float horizontalAxis;
        private float verticalAxis;
        private GameObject inspectedObject;

        [Header("Attribute Configurations")]
        [SerializeField] private float mouseSensitivity = 6f;
        [SerializeField] private string noClipWallLayer = "NoClipWall";

        [Header("Object References")]
        [SerializeField] private Transform inspectorTransform;
        [SerializeField] private GameObject shadow;



        //==============================================================================
        // Functions
        //==============================================================================
        #region MonoBehaviour methods
        private void Update()
        {
            GetInput();
            Rotate();
        }
        #endregion



        #region ProjectBorderland methods
        /// <summary>
        /// Gets input from Unity Input Manager.
        /// </summary>
        private void GetInput()
        {
            if (Input.GetKeyDown(InputController.Instance.Inspect))
            {
                if (isInspecting)
                {
                    DisableInspecting();
                }

                else
                {
                    EnableInspecting();
                }
            }

            if (Input.GetKey(KeyCode.Mouse0))
            {
                horizontalAxis = Input.GetAxis("Mouse X") * mouseSensitivity;
                verticalAxis = Input.GetAxis("Mouse Y") * mouseSensitivity;
            }

            else
            {
                horizontalAxis = 0f;
                verticalAxis = 0f;
            }
        }



        /// <summary>
        /// Enters inspecting mode.
        /// </summary>
        private void EnableInspecting()
        {
            ItemSO item = InventoryManager.GetCurrentIndex();

            if (!item.IsNullItem)
            {
                isInspecting = true;
                GameManager.EnterInspection();
                InstantiateInspectedObject(item);
                shadow.SetActive(true);
            }
        }



        /// <summary>
        /// Inspects object.
        /// </summary>
        /// <param name="item"></param>
        private void InstantiateInspectedObject(ItemSO item)
        {
            inspectedObject = Instantiate(item.Prefab, inspectorTransform.position, Quaternion.identity);

            List<GameObject> _objects = new List<GameObject>();
            _objects.Add(inspectedObject);

            for (int i = 0; i < inspectedObject.transform.childCount; i++)
            {
                _objects.Add(inspectedObject.transform.GetChild(i).gameObject);
            }

            AssignNoClipLayer(_objects);

            inspectedObject.transform.forward = Camera.main.transform.forward;
            inspectedObject.TryGetComponent<BoxCollider>(out BoxCollider collider);
            collider.enabled = false;
        }



        /// <summary>
        /// Assigns no clip layers for objects.
        /// </summary>
        private void AssignNoClipLayer(List<GameObject> _objects)
        {
            foreach (GameObject _object in _objects)
            {
                _object.layer = LayerMask.NameToLayer(noClipWallLayer);
            }
            
        }



        /// <summary>
        /// Exits inspecting mode.
        /// </summary>
        private void DisableInspecting()
        {
            isInspecting = false;
            GameManager.ExitInspection();
            shadow.SetActive(false);

            if (inspectedObject != null)
            {
                Destroy(inspectedObject);
            }
        }



        /// <summary>
        /// Rotates inspected object around input axis.
        /// </summary>
        private void Rotate()
        {
            if (isInspecting && inspectedObject != null)
            {
                inspectedObject.transform.Rotate(Camera.main.transform.up, -horizontalAxis, Space.World);
                inspectedObject.transform.Rotate(Camera.main.transform.right, verticalAxis, Space.World);
            }
        }
        #endregion
    }
}