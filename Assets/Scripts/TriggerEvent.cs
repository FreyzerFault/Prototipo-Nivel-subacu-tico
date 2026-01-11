using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{
    public UnityEvent triggerEvent;
    
    private void OnTriggerEnter(Collider other)
    {
        triggerEvent?.Invoke();
    }
}
