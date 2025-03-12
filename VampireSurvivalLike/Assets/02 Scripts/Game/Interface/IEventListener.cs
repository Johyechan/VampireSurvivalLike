using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventListener<T>
{
    public void OnEvent(T t);
}
