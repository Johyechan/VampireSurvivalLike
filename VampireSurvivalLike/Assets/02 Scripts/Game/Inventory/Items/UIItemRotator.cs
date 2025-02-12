using UnityEngine;

public class UIItemRotator : MonoBehaviour
{
    // q를 누르면 왼쪽으로 90도 회전 e를 누르면 오른쪽으로 90도 회전
    // 저 + 해주는 값들이 나오는 기준만 알면 된다
    // 보정값 찾기
    // 만약에 x나 y축들 중에서 마이너스 값이 존재하면 -가장 큰 값 - 가장 작은값
    // 만약에 마이너스가 없고 0이 존재하지 않을경우 -가장 큰 값 + 가장 작은 값 
    /*
     *  0도
        (0,0) (1,0)
        (0,1)
        (0,2)

        270(-90)도
        (0,0)				    (0,-1)              +    (0,1)
        (0,1) (1,1) (2,1)		(0,0) (1,0) (2,0)   +    (0,1) (0,1) (0,1)           

        180도
              (1,0)		            (2,-2)          +           (-1,2)
              (1,1)		            (2,-1)          +           (-1,2)
        (0,2) (1,2)		      (1,0) (2,0)	        +    (-1,2) (-1,2)

        90(-270)도
        (0,0) (1,0) (2,0)		(-2,0) (-1,0) (0,0)     +       (2,0) (2,0) (2,0)
                    (2,1)		              (0,1)     +                   (2,0)

        270(-90)도
        x' = y
        y' = -x

        180도
        x' = 2 * cx - x
        y' = 2 * cy - y

        90(-270)도
        x' = -y
        y' = x
    */

    public Vector2Int[] RotateItem(Vector2Int[] shape, bool right = true)
    {
        int xAdjust = 1;
        int yAdjust = 1;
        int temp = 0;

        Vector2Int bigest = Vector2Int.zero;
        Vector2Int smallest = Vector2Int.zero;

        for (int i = 0; i < shape.Length; i++)
        {
            if (right)
            {
                temp = shape[i].x;
                shape[i].x = -shape[i].y;
                shape[i].y = temp;
            }
            else
            {
                temp = shape[i].x;
                shape[i].x = shape[i].y;
                shape[i].y = -temp;
            }


            if (xAdjust > 0)
            {
                xAdjust = CheckValueNeedAdjustX(shape[i]);
            }
            else if (xAdjust == 0)
            {
                if (shape[i].x < 0)
                {
                    xAdjust = CheckValueNeedAdjustX(shape[i]);
                }
            }

            if (yAdjust > 0)
            {
                yAdjust = CheckValueNeedAdjustY(shape[i]);
            }
            else if (yAdjust == 0)
            {
                if (shape[i].y < 0)
                {
                    yAdjust = CheckValueNeedAdjustY(shape[i]);
                }
            }

            bigest.x = CheckBigest(bigest.x, shape[i].x);
            bigest.y = CheckBigest(bigest.y, shape[i].y);

            smallest.x = CheckSmallest(smallest.x, shape[i].x);
            smallest.y = CheckSmallest(smallest.y, shape[i].y);
        }

        if (xAdjust != 0 || yAdjust != 0)
        {
            for (int i = 0; i < shape.Length; i++)
            {
                if (xAdjust != 0)
                {
                    shape[i].x += Adjust(bigest.x, smallest.x, xAdjust);
                }
                if (yAdjust != 0)
                {
                    shape[i].y += Adjust(bigest.y, smallest.y, yAdjust);
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
