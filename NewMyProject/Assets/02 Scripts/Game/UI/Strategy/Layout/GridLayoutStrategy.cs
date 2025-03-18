using MyUI.Interface;
using UnityEngine;

namespace MyUI.Strategy.Layout
{
    public class GridLayoutStrategy : IUILayoutStrategy
    {
        public Vector2 GetPosition(RectTransform parentRectTrans, int x, int y, int width, int height, float spacing)
        {
            // ���� UI�� �ʺ�� ���̸� ��������
            float panelWidth = parentRectTrans.rect.width;
            float panelHeight = parentRectTrans.rect.height;

            // pivot�� ���� ������ ���� �ٸ���
            // �� pivot�� �߽����� ��� �󸶳� ������ ��ǥ�� �ִ°��� ��ȯ
            // ��) (200, 300)
            float panelPosX = parentRectTrans.anchoredPosition.x;
            float panelPosY = parentRectTrans.anchoredPosition.y;

            // pivot�� ���� ���� �ϴ� (0, 0) �߾� (0.5, 0.5) ���� ��� (1,1)
            float pivotX = parentRectTrans.pivot.x;
            float pivotY = parentRectTrans.pivot.y;

            // �θ��� ������ ����Ͽ� ������ ui�� ��Ȯ�� ��ġ�� ���� ã�� ��
            float AdjustedX = panelPosX - panelWidth * pivotX;
            float AdjustedY = panelPosY + panelHeight * pivotY;

            // -1 �� �ϴ� ������ �����Ǵ� ��ü�� ������ ��ġ�� �߽��� �� �׷��⿡ ���� �� �� �ʿ� �����Ǵ� ��ü�� ������ �ʿ䰡 ���� ���� �ٵ� �̰� �������� ������ �ϳ� �� ������ 1�� ������ ����
            float totalWidth = (x - 1) * width + (x - 1) * spacing; // width = ������ ��ü�� �ʺ� spacing�� ����
            float totalHeight = (y - 1) * height + (y - 1) * spacing; // height = ������ ��ü�� ����

            // �ʺ�� ���̿��� ���������� ���� ����� �ʺ�� ���̸� ���� ���� ���� 2�� ������ ������ ������ �� ������ �� ������ �� ������ �� ���� �Ϸ���
            // �� �߽��� ���߷���
            float offsetX = (panelWidth - totalWidth) / 2;
            float offsetY = (panelHeight - totalHeight) / 2;

            // ù ��° ������ ��ġ�� ����
            return new Vector2(AdjustedX + offsetX, AdjustedY - offsetY);
        }
    }
}

