using UnityEditor;
using UnityEditor.EditorTools;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;

namespace _Tools.SnappingTool.Editor
{
    [EditorTool("Custom Snap Move", typeof(CustomSnap))]
    public class CustomSnappingTool : EditorTool
    {
        public Texture2D ToolIcon = default;
        public float SnapDistance = .5f;

        private Transform oldTarget;
        private CustomSnapPoint[] allPoints;
        private CustomSnapPoint[] targetPoints;

        public override GUIContent toolbarIcon =>
            new GUIContent
            {
                image = ToolIcon,
                text = "Custom Snap Move Tool"
            };

        private void OnEnable()
        {
            
        }

#if UNITY_EDITOR
        public override void OnToolGUI(EditorWindow window)
        {
            Transform targetTransform = ((CustomSnap) target).transform;

            if (targetTransform != oldTarget)
            {
                PrefabStage prefabStage = PrefabStageUtility.GetPrefabStage(targetTransform.gameObject);

                allPoints = prefabStage != null ? prefabStage.prefabContentsRoot.GetComponentsInChildren<CustomSnapPoint>() : FindObjectsOfType<CustomSnapPoint>();
                
                targetPoints = targetTransform.GetComponentsInChildren<CustomSnapPoint>();  

                oldTarget = targetTransform;
            }

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

            Vector3 bestPosition = newPosition;
            float closestDistance = float.PositiveInfinity;

            foreach (CustomSnapPoint point in allPoints)
            {
                if (point.transform.parent == targetTransform) continue;

                foreach (CustomSnapPoint ownPoint in targetPoints)
                {
                    if (ownPoint.Type != point.Type) continue;

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
