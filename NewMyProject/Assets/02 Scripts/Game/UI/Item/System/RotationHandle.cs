using MyUI.Interface;
using MyUI.Struct;
using UnityEngine;

namespace MyUI.Item.HandleSystem
{
    public class RotationHandle : IRotation
    {
        // q�� ������ �������� 90�� ȸ�� e�� ������ ���������� 90�� ȸ��
        // �� + ���ִ� ������ ������ ���ظ� �˸� �ȴ�
        // ������ ã��
        // ���࿡ x�� y��� �߿��� ���̳ʽ� ���� �����ϸ� -���� ū �� - ���� ������
        // ���࿡ ���̳ʽ��� ���� 0�� �������� ������� -���� ū �� + ���� ���� �� 
        /*
         *  0��
            (0,0) (1,0)
            (0,1)
            (0,2)

            270(-90)��
            (0,0)				    (0,-1)              +    (0,1)
            (0,1) (1,1) (2,1)		(0,0) (1,0) (2,0)   +    (0,1) (0,1) (0,1)           

            180��
                  (1,0)		            (2,-2)          +           (-1,2)
                  (1,1)		            (2,-1)          +           (-1,2)
            (0,2) (1,2)		      (1,0) (2,0)	        +    (-1,2) (-1,2)

            90(-270)��
            (0,0) (1,0) (2,0)		(-2,0) (-1,0) (0,0)     +       (2,0) (2,0) (2,0)
                        (2,1)		              (0,1)     +                   (2,0)

            270(-90)��
            x' = y
            y' = -x

            180��
            x' = 2 * cx - x
            y' = 2 * cy - y

            90(-270)��
            x' = -y
            y' = x
        */

        public ItemShape Rotate(ItemShape shape, bool isRignt = true)
        {
            int xAdjust = 1;
            int yAdjust = 1;
            int temp = 0;

            Vector2Int bigest = Vector2Int.zero;
            Vector2Int smallest = Vector2Int.zero;

            for (int i = 0; i < shape.shape.Length; i++)
            {
                if (isRignt)
                {
                    temp = shape.shape[i].x;
                    shape.shape[i].x = -shape.shape[i].y;
                    shape.shape[i].y = temp;
                }
                else
                {
                    temp = shape.shape[i].x;
                    shape.shape[i].x = shape.shape[i].y;
                    shape.shape[i].y = -temp;
                }


                if (xAdjust > 0)
                {
                    xAdjust = CheckValueNeedAdjustX(shape.shape[i]);
                }
                else if (xAdjust == 0)
                {
                    if (shape.shape[i].x < 0)
                    {
                        xAdjust = CheckValueNeedAdjustX(shape.shape[i]);
                    }
                }

                if (yAdjust > 0)
                {
                    yAdjust = CheckValueNeedAdjustY(shape.shape[i]);
                }
                else if (yAdjust == 0)
                {
                    if (shape.shape[i].y < 0)
                    {
                        yAdjust = CheckValueNeedAdjustY(shape.shape[i]);
                    }
                }

                bigest.x = CheckBigest(bigest.x, shape.shape[i].x);
                bigest.y = CheckBigest(bigest.y, shape.shape[i].y);

                smallest.x = CheckSmallest(smallest.x, shape.shape[i].x);
                smallest.y = CheckSmallest(smallest.y, shape.shape[i].y);
            }

            if (xAdjust != 0 || yAdjust != 0)
            {
                for (int i = 0; i < shape.shape.Length; i++)
                {
                    if (xAdjust != 0)
                    {
                        shape.shape[i].x += Adjust(bigest.x, smallest.x, xAdjust);
                    }
                    if (yAdjust != 0)
                    {
                        shape.shape[i].y += Adjust(bigest.y, smallest.y, yAdjust);
                    }
                }
            }

            return shape;
        }

        private int CheckBigest(int value1, int value2)
        {
            if (value1 < value2)
            {
                return value2;
            }
            else
            {
                return value1;
            }
        }

        private int CheckSmallest(int value1, int value2)
        {
            if (value1 > value2)
            {
                return value2;
            }
            else
            {
                return value1;
            }
        }

        private int Adjust(int bigest, int smallest, int isMinus)
        {
            if (isMinus < 0)
            {
                return -bigest - smallest;
            }
            else
            {
                return -bigest + smallest;
            }
        }

        private int CheckValueNeedAdjustX(Vector2Int vec)
        {
            if (vec.x < 0)
            {
                return -1;
            }
            else if (vec.x == 0)
            {
                return 0;
            }

            return 1;
        }

        private int CheckValueNeedAdjustY(Vector2Int vec)
        {
            if (vec.y < 0)
            {
                return -1;
            }
            else if (vec.y == 0)
            {
                return 0;
            }

            return 1;
        }
    }
}

