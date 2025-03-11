using EffectDecorator;
using Manager;
using MyInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Torch : NonCombatItemBase
{
    private IEffect _effect;

    private float _damage = 0.1f;
    private float _duration = 5.0f;

    protected override void Awake()
    {
        base.Awake();

        _effect = new DotDamageDecorator(_effect, _duration, _damage);
    }

    private void OnEnable()
    {
        Init(so, _effect);
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
    }
}
