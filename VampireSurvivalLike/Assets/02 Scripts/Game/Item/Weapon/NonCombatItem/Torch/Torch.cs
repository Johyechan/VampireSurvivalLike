using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Torch : NonCombatItemBase
{
    protected override void Awake()
    {
        base.Awake();
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);

        if(transform.parent.name == "Canvas")
        {
            // ���� �߰� �� ȿ�� �߰�
        }
    }
}
