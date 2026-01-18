using UnityEngine;
using UnityEngine.Events;

namespace Utils
{
    public class TriggerEvent : MonoBehaviour
    {
        public UnityEvent triggerEvent;

        private MeshRenderer mr;

        private void Awake()
        {
            mr = GetComponent<MeshRenderer>();
            mr.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            triggerEvent?.Invoke();
        }
    }
}
