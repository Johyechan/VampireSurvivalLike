using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseButton : MonoBehaviour
{
    protected virtual void Start()
    {
        
    }

    public abstract void OnCliked();
}
