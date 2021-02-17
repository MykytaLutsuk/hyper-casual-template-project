using System;
using UnityEngine;

namespace _Tools.SnappingTool
{
    public class CustomSnapPoint : MonoBehaviour
    {
        public enum ConnectionType
        {
            Default = 0
        }

        public ConnectionType Type;
        
        private void OnDrawGizmos()
        {
            switch (Type)
            {
                case ConnectionType.Default:
                {
                    Gizmos.color = Color.green;
                    break;
                }
                default:
                {
                    throw new ArgumentOutOfRangeException();
                    break;
                }
            }
            
            Gizmos.DrawSphere(transform.position, .1f);
        }
    }
}
