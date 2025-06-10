using UnityEngine.SceneManagement;

public static class SceneControl
{
    // Reloads the current scene //
    public static void Reload() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    // Loads a given scene by it's build index //
    public static void Load(int index) => SceneManager.LoadScene(index);
}
