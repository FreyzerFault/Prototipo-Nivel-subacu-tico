using System.Collections;
using UnityEngine;

public class Flickering : MonoBehaviour
{
    public float minFlickDelay = 0.2f;
    public float maxFlickDelay = 1.5f;
    public float flickTime = 0.2f;
    
    private Light light;

    private void Awake() => light = GetComponent<Light>();

    private void Start() => StartCoroutine(FlickeringSubroutine());

    private IEnumerator FlickeringSubroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minFlickDelay, maxFlickDelay));
            light.enabled = false;
            yield return new WaitForSeconds(flickTime);
            light.enabled = true;
        }
    }
}
