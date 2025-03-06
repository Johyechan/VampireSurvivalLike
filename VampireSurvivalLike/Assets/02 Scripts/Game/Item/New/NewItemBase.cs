using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewItemBase : MonoBehaviour
{
    protected virtual void Awake()
    {
        gameObject.name += GameManager.Instance.itemNum++;
    }
}
