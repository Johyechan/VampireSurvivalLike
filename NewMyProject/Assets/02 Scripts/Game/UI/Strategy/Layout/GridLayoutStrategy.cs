using MyUI.Interface;
using UnityEngine;

namespace MyUI.Strategy.Layout
{
    public class GridLayoutStrategy : IUILayoutStrategy
    {
        public Vector2 GetPosition(RectTransform parentRectTrans, int x, int y, int width, int height, float spacing)
        {
            // 현재 UI의 너비와 높이를 가져오자
            float panelWidth = parentRectTrans.rect.width;
            float panelHeight = parentRectTrans.rect.height;

            // pivot에 따라 나오는 값이 다르다
            // 즉 pivot을 중심으로 잡아 얼마나 떨어진 좌표에 있는가를 반환
            // 예) (200, 300)
            float panelPosX = parentRectTrans.anchoredPosition.x;
            float panelPosY = parentRectTrans.anchoredPosition.y;

            // pivot을 구함 왼쪽 하단 (0, 0) 중앙 (0.5, 0.5) 우측 상단 (1,1)
            float pivotX = parentRectTrans.pivot.x;
            float pivotY = parentRectTrans.pivot.y;

            // 부모의 기준을 고려하여 생성될 ui가 정확히 배치될 곳을 찾는 것
            float AdjustedX = panelPosX - panelWidth * pivotX;
            float AdjustedY = panelPosY + panelHeight * pivotY;

            // -1 을 하는 이유는 생성되는 객체의 중점이 위치의 중심이 됨 그렇기에 각각 맨 끝 쪽에 생성되는 객체의 절반은 필요가 없는 거임 근데 이게 양쪽으로 절반이 하나 씩 있으니 1이 빠지는 거지
            float totalWidth = (x - 1) * width + (x - 1) * spacing; // width = 생성될 객체의 너비 spacing은 간격
            float totalHeight = (y - 1) * height + (y - 1) * spacing; // height = 생성될 객체의 높이

            // 너비와 높이에서 총합적으로 내가 사용할 너비와 높이를 빼고 나은 곳을 2로 나누는 이유는 좌측에 반 우측에 반 상측에 반 하측에 반 으로 하려고
            // 즉 중심을 맞추려고
            float offsetX = (panelWidth - totalWidth) / 2;
            float offsetY = (panelHeight - totalHeight) / 2;

            // 첫 번째 생성될 위치를 구함
            return new Vector2(AdjustedX + offsetX, AdjustedY - offsetY);
        }
    }
}

