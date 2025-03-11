using CombatItem;
using EffectDecorator;
using Manager;
using MyInterface;
using MyStat;
using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Torch : NonCombatItemBase
{
    private ItemStat _stat;

    private IEffect _effect;

    private float _damage = 0.1f;
    private float _duration = 5.0f;
    private float _radiusValue = 0.5f;

    protected override void Awake()
    {
        base.Awake();

        _effect = new DotDamageDecorator(_effect, _duration, _damage);
    }

    public void TorchEffect()
    {
        if (transform.parent.name == "InventoryPanel")
        {
            Debug.Log($"In Canvas {transform.parent}");
            StatManager.Instance.AddItemStat(gameObject.name, _stat);
            LightManager.Instance.SetFOVRadius(LightManager.Instance.FovLightRadius + _radiusValue);

            if (_effect != null)
            {
                PlayerBackpack backpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();
                foreach (var weapon in backpack.BackpackWeaponMap)
                {
                    Debug.Log(weapon.Value.name);
                    CombatItemBase combatItem = weapon.Value.GetComponent<CombatItemBase>();
                    combatItem.SetEffect(_effect);
                }
            }
        }
        else if (transform.parent.name != "InventoryPanel")
        {
            Debug.Log($"Out Canvas {transform.parent}");
            StatManager.Instance.RemoveItemStat(gameObject.name);
            LightManager.Instance.SetFOVRadius(LightManager.Instance.FovLightRadius - _radiusValue);

            if (_effect != null)
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
