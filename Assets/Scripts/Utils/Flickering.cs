using System.Collections;
using UnityEngine;

namespace Utils
{
    public class Flickering : MonoBehaviour
    {
        public float minFlickDelay = 0.2f;
        public float maxFlickDelay = 1.5f;
        public float flickTime = 0.2f;
    
        private Light light;

        private float initialIntensity;
        private float offIntensity = 5;

        private void Awake() => light = GetComponent<Light>();

        private void Start() => StartCoroutine(FlickeringSubroutine());

        private IEnumerator FlickeringSubroutine()
        {
            initialIntensity = light.intensity;
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minFlickDelay, maxFlickDelay));
                light.intensity = offIntensity;
                yield return new WaitForSeconds(flickTime);
                light.intensity = initialIntensity;
            }
        }
    }
}
