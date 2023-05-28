using UnityEngine;
using ProjectBorderland.InventorySystem;

namespace ProjectBorderland.Interaction
{
    /// <summary>
    /// Interface for interactable objects.
    /// </summary>
    public interface IInteractable
    {
        string InteractUIText
        {
            get;
            set;
        }

        /// <summary>
        /// Interacts with object.
        /// </summary>
        void Interact();


        /// <summary>
        /// Interacts with object using another object.
        /// </summary>
        void Interact(ItemSO item);
    }

    public struct ShowHoverTextMessage
    {
        public string text;

        public ShowHoverTextMessage(string text)
        {
            this.text = text;
        }
    }



    public struct HideHoverTextMessage
    {}
}
