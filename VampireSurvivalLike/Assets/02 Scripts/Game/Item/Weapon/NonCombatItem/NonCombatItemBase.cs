using Item;
using Manager;
using MyInterface;
using MySO;
using MyStat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NonCombatItemBase : ItemBase, IEndDragHandler
{
    private ItemSO _nonCombatItemSO;

    private ItemStat _stat;

    private IEffect _effect;

    protected override void Awake()
    {
        base.Awake();
    }

    protected void Init(ItemSO so, IEffect effect)
    {
        _nonCombatItemSO = so;
        _stat = StatManager.Instance.SetStat(so);
        _effect = effect;
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        if(transform.parent.name == "SaveBox")
        {
            // 스탯 제거 및 효과 제거
        }
    }
}
