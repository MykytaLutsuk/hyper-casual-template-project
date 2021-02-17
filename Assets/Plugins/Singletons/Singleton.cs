using UnityEngine;

namespace Plugins.Singletons
{
    /// <summary>
    /// One of the simplest implementation of Singleton Design Pattern.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Reference to our singular instance.
        private static T instance;
        public static T Instance => instance;

        /// <summary>
        /// Unity method called just after object creation - like constructor.
        /// </summary>
        protected virtual void Awake()
        {
            // If we don't have reference to instance than this object will take control
            if (instance == null)
            {
                instance = this as T;
            }
            else if (instance != this) // Else this is other instance and we should destroy it!
            {
                Destroy(this);
            }
        }

        /// <summary>
        /// Unity method called before object destruction.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (instance != this) // Skip if instance is other than this object.
            {
                return;
            }

            instance = null;
        }
    }
}

