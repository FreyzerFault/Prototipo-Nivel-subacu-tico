using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class SceneLoader : SingletonPersistent<SceneLoader>
{
    #region TRANSITIONS

    [SerializeField] private FadeIn fadeImage;
    
    private FadeIn FadeImage => fadeImage ??= FindObjectsByType<FadeIn>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];


    public void LoadSceneWithFadeOut(string sceneName, Color fadeColor = default) =>
        LoadSceneWithFadeOut(SceneManager.GetSceneByName(sceneName).buildIndex, fadeColor);
    
    public void LoadSceneWithFadeOut(int buildIndex, Color fadeColor = default)
    {
        fadeImage = FindObjectsByType<FadeIn>(FindObjectsInactive.Include, FindObjectsSortMode.None)[0];
        FadeImage.Color = fadeColor;
        FadeImage.DoFadeIn();
        StartCoroutine(LoadSceneAsyncDelayed(buildIndex, 0.5f));
    }
    

    #endregion
    
    #region SCENE MANAGEMENT
    public void ResetScene() => LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    public void LoadScene(string sceneName) => 
        LoadScene(SceneManager.GetSceneByName(sceneName).buildIndex);
    
    public void LoadScene(int buildIndex) => SceneManager.LoadScene(buildIndex);
    
    public void LoadSceneAsync(int buildIndex) => SceneManager.LoadSceneAsync(buildIndex);

    private IEnumerator LoadSceneDelayed(int buildIndex, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadScene(buildIndex);
    } 
    
    private IEnumerator LoadSceneAsyncDelayed(int buildIndex, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadSceneAsync(buildIndex);
    } 

    #endregion
}
