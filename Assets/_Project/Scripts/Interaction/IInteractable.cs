using UnityEngine;

namespace ProjectBorderland.Interaction
{
    /// <summary>
    /// Interface for interactable objects.
    /// </summary>
    public interface IInteractable
    {
        /// <summary>
        /// Interacts with object.
        /// </summary>
        void Interact();


        /// <summary>
        /// Interacts with object using another object.
        /// </summary>
        void Interact(GameObject _object);
    }
}
