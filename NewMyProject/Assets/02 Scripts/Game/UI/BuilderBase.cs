using MyUtil.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace MyUI
{
    public class BuilderBase : MonoBehaviour
    {
        [SerializeField] protected List<ObjectPoolType> _types = new List<ObjectPoolType>();

        [SerializeField] protected Transform _parentTrans;

        [SerializeField] protected int _objXCount;
        [SerializeField] protected int _objYCount;

        [SerializeField] protected float _objWidth;
        [SerializeField] protected float _objHeight;
        [SerializeField] protected float _spacing;
    }
}

