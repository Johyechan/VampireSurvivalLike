using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnlyInventoryItem : MonoBehaviour, IEndDragHandler
{
    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        
    }

    void Update()
    {
        // 부모가 Canvas면 스탯을 추가 및 추가효과 발동
        // 아니면 스탯 제거 및 추가효과 발동 정지
    }
}
