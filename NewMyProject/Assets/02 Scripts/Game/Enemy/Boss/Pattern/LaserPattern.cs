using Enemy.Boss.Interface;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public abstract class LaserPattern : IBossPattern
    {
        public abstract void Pattern();

        public abstract void PatternEnd();

        protected abstract IEnumerator PatternCo();

        protected void CreateLaser(LineRenderer line, Vector3 startPos, Vector3 endPos, float width, Color color, float length)
        {
            line.startColor = color;
            line.startWidth = width;
            line.SetPosition(0, startPos);
            line.SetPosition(1, startPos + endPos * length);
            line.endWidth = width;
            line.endColor = color;
        }

        protected int GetLaserMoveDirection(LineRenderer line, Vector3 currentPos, Vector3 targetPos)
        {
            float cross = currentPos.x * targetPos.y - targetPos.x * currentPos.y;

            if(cross < 0)
            {
                // ¿À¸¥ÂÊ
                return -1;
            }
            else
            {
                // ¿ÞÂÊ
                return 1;
            }
        }

        protected IEnumerator RotateLaser(LineRenderer line, Vector2 currentPos, float rotateSpeed, float length, float rotateTime, int right)
        {
            float angle = 0;
            float curTime = 0;
            Vector2 startPos = line.GetPosition(0);

            while(curTime < rotateTime)
            {
                curTime += Time.deltaTime;
                angle += rotateSpeed * Time.deltaTime * right;
                float rad = angle * Mathf.Deg2Rad;

                Vector2 rotatedDir = new Vector2(
                    currentPos.x * Mathf.Cos(rad) - currentPos.y * Mathf.Sin(rad),
                    currentPos.x * Mathf.Sin(rad) + currentPos.y * Mathf.Cos(rad)
                );

                line.SetPosition(1, startPos + rotatedDir * length);

                yield return null;
            }
        }
    }
}

