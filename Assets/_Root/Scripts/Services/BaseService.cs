using _Root.Scripts.MonoExtension;

namespace _Root.Scripts.Services
{
    public abstract class BaseService : MonoCached
    {
        public abstract void Init();
    }
}
