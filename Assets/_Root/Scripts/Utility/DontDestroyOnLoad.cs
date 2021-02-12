using _Root.Scripts.MonoExtension;

namespace _Root.Scripts.Utility
{
    public class DontDestroyOnLoad : MonoCached
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}
