using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Root.Scripts
{
    public class Boot : MonoBehaviour
    {
        [SerializeField] private string sceneNameToLoad = default;

        [Range(0f, 5f)]
        [SerializeField] private float loadTime = 0f;

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

            asyncLoad.allowSceneActivation = false;

            float timer = loadTime;
            // Wait until the asynchronous scene fully loads
            while (asyncLoad.progress < .9f || timer > 0f)
            {
                timer -= Time.deltaTime;
                yield return null;
            }
            
            asyncLoad.allowSceneActivation = true;
        }
    }
}
