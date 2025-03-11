using CombatItem;
using EffectDecorator;
using Item;
using Manager;
using MyInterface;
using MySO;
using MyStat;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NonCombatItemBase : ItemBase, IEndDragHandler
{
    private ItemStat _stat;

    private IEffect _effect;

    private float _radiusValue = 0.5f;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Init(ItemSO so, IEffect effect)
    {
        // 이게 왜 널이 되는거지
        Debug.Log(so);
        _stat = StatManager.Instance.SetStat(so);
        _effect = effect;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if (transform.parent.name == "Canvas")
        {
            StatManager.Instance.AddItemStat(gameObject.name, _stat);
            LightManager.Instance.SetFOVRadius(LightManager.Instance.FovLightRadius + _radiusValue);

            if(_effect != null)
            {
                PlayerBackpack backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();
                foreach (var weapon in backpack.BackpackWeaponMap)
                {
                    CombatItemBase combatItem = weapon.Value.GetComponent<CombatItemBase>();
                    combatItem.SetEffect(_effect);
                }
            }
        }
        else
        {
            StatManager.Instance.RemoveItemStat(gameObject.name);
            LightManager.Instance.SetFOVRadius(LightManager.Instance.FovLightRadius - _radiusValue);

            if(_effect != null)
            {
                PlayerBackpack backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();
                foreach (var weapon in backpack.BackpackWeaponMap)
                {
                    CombatItemBase combatItem = weapon.Value.GetComponent<CombatItemBase>();
                    combatItem.SetEffect(DecoratorManager.Instance.RemoveEffect<DotDamageDecorator>(_effect));
                }
            }
        }
    }
}
