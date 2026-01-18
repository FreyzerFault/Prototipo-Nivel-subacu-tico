using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public static int SceneIndexToLoad = 0;
    
    [SerializeField] private Slider slider;
    [SerializeField] private TMP_Text completionText;

    public float Completion
    {
        get => slider.value;
        set
        {
            slider.value = value;
            completionText.text = $"{value * 100} %";
        }
    }

    public void Start() => StartCoroutine(LoadSceneCoroutine(SceneIndexToLoad));

    private IEnumerator LoadSceneCoroutine(int sceneIndex)
    {
        Completion = 0;
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex);

        if (op == null) Debug.Log($"Scene with index {sceneIndex} not found. Can't load scene");
        
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            Completion = progress;
            yield return null;
        }
    }
}
