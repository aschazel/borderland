using System;
using System.Collections.Generic;
using ProjectBorderland.Progression;
using ProjectBorderland.Interaction;

namespace ProjectBorderland.Save
{
    /// <summary>
    /// Represents a save data.
    /// </summary>
    [Serializable]
    public class SaveData
    {
        //==============================================================================
        // Variables
        //==============================================================================
        public string Name;
        public Objective LastObjective;
        public List<DynamicObject> DynamicObjects = new List<DynamicObject>();
        public List<PickableItem> PickableItems = new List<PickableItem>();
    }
}