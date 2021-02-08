using UnityEngine;

namespace _Root.Scripts.Data
{
    public static class EarlyObjectCreator
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void CreatePlayerProfile()
        {
            GameObject playerProfileObject = new GameObject {name = "Player Profile"};
            playerProfileObject.AddComponent<PlayerProfile>();
        }
    }
}
