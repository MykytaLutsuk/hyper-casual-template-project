using _Root.Scripts.Singletons;

namespace _Root.Scripts
{
    public class GlobalEvents : PersistentSingleton<GlobalEvents>
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
