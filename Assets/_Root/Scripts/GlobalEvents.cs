using Plugins.Singletons;

namespace _Root.Scripts
{
    public class GlobalEvents : Singleton<GlobalEvents>
    {
        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
