using UnityEngine;

public abstract class SOBase<T> : ScriptableObject
{
    public abstract T DeepCopy();
}
