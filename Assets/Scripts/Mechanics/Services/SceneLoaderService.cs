using UnityEngine.SceneManagement;

namespace Homework2.Mechanics.Services
{
    public class SceneLoaderService
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public static void LoadMainMenu() => LoadScene("MainMenu");

        public static void QuitApplication()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}