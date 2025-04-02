using Manager;
using UnityEngine;

public abstract class EventSubscriber : MonoBehaviour
{
    protected abstract void SubscribeEvents();
    protected abstract void UnsubscribeEvents();

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }
}
