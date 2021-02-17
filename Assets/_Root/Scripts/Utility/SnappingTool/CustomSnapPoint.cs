using UnityEngine;

namespace _Root.Scripts.Utility.SnappingTool
{
    public class CustomSnapPoint : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, .1f);
        }
    }
}
