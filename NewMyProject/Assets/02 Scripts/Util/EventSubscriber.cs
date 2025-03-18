using UnityEngine;

public abstract class EventSubscriber : MonoBehaviour
{
    private bool _isQuitting = false;

    protected abstract void SubscribeEvents();
    protected abstract void UnsubscribeEvents();

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void OnDisable()
    {
        if(!_isQuitting)
        {
            UnsubscribeEvents();
        }
    }

    private void OnApplicationQuit()
    {
        _isQuitting = true;
        UnsubscribeEvents();
    }
}
