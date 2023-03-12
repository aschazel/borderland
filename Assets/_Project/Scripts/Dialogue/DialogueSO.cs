using System.Collections.Generic;
using UnityEngine;

namespace ProjectBorderland.Dialogue
{
    /// <summary>
    /// Represents a dialog.
    /// </summary>
    [CreateAssetMenu(menuName = "Dialogue/Create new Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        //==============================================================================
        // Variables
        //==============================================================================
        [Header("Object References")]
        [SerializeField] private List<Sentence> sentences = new List<Sentence>();
        public List<Sentence> Sentences { get { return sentences; } }

        [System.Serializable]
        public struct Sentence
        {
            [SerializeField] private CharacterSO author;
            public CharacterSO Author { get { return author; } }
            [SerializeField] [TextArea] private string say;
            public string Say { get { return say; } }
        }
    }
}