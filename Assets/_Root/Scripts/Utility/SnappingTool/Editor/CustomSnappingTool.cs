using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace _Root.Scripts.Utility.SnappingTool.Editor
{
    [EditorTool("Custom Snap Move", typeof(CustomSnap))]
    public class CustomSnappingTool : EditorTool
    {
        public Texture2D ToolIcon = default;
        public float SnapDistance = .5f;

        public override GUIContent toolbarIcon =>
            new GUIContent
            {
                image = ToolIcon,
                text = "Custom Snap Move Tool"
            };

#if UNITY_EDITOR
        public override void OnToolGUI(EditorWindow window)
        {
            Transform targetTransform = ((CustomSnap) target).transform;

            EditorGUI.BeginChangeCheck();
            Vector3 newPosition = Handles.PositionHandle(targetTransform.position, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(targetTransform, "Move with snap tool");
                MoveWithSnapping(targetTransform, newPosition);
            }
        }

        private void MoveWithSnapping(Transform targetTransform, Vector3 newPosition)
        {
            CustomSnapPoint[] allPoints = FindObjectsOfType<CustomSnapPoint>();
            CustomSnapPoint[] targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();

            Vector3 bestPosition = newPosition;
            float closestDistance = float.PositiveInfinity;

            foreach (CustomSnapPoint point in allPoints)
            {
                if (point.transform.parent == targetTransform) continue;

                foreach (CustomSnapPoint ownPoint in targetPoints)
                {
                    Vector3 targetPos = point.transform.position - (ownPoint.transform.position - targetTransform.position);
                    float distance = Vector3.Distance(targetPos, newPosition);

                    if (distance < closestDistance)
                    {
                        closestDistance = distance;
                        bestPosition = targetPos;
                    }
                }
            }

            targetTransform.position = closestDistance < SnapDistance ? bestPosition : newPosition;
        }
#endif
    }
}
