using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root.Scripts
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private string sceneNameToLoad = default;

        private void Start()
        {
            StartCoroutine(LoadAsyncScene(sceneNameToLoad));
        }

        private IEnumerator LoadAsyncScene(string scene)
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
