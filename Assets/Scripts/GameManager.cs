using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SCENE MANAGEMENT

    public void ResetScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);
    public void LoadScene(string sceneName) => SceneManager.LoadScene(sceneName);

    #endregion
}
