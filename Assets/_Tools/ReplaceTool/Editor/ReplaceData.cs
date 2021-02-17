using UnityEngine;

namespace _Tools.ReplaceTool.Editor
{
    /// <summary>
    /// Data class for replace tool.
    /// </summary>
    public class ReplaceData : ScriptableObject
    {
        // Reference to replace object.
        public GameObject replaceObject;

        // Array of object to replace.
        public GameObject[] objectsToReplace;
    }
}