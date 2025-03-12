using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent<T>
{
    private readonly List<IEventListener<T>> _listeners = new();

    public void EventCall(T t)
    {
        foreach(var listener in _listeners)
        {
            listener.OnEvent(t);
        }
    }

    public void AddEvent(IEventListener<T> t)
    {
        if(!_listeners.Contains(t))
        {
            _listeners.Add(t);
        }
    }

    public void RemoveEvent(IEventListener<T> t)
    {
        if(_listeners.Contains(t))
        {
            _listeners.Remove(t);
        }
    }
}
