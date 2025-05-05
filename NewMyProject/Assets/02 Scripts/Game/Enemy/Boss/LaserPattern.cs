using Enemy.Boss.Interface;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Boss
{
    public abstract class LaserPattern : IBossPattern
    {
        public abstract void Pattern();

        protected abstract IEnumerator PatternCo();

        protected void CreateLaser(LineRenderer line, Vector3 startPos, Vector3 endPos, float startWidth, float endWidth, Color startColor, Color endColor)
        {
            line.startColor = startColor;
            line.startWidth = startWidth;
            line.SetPosition(0, startPos);
            line.SetPosition(1, endPos);
            line.endWidth = endWidth;
            line.endColor = endColor;
        }

        protected int MoveLaser(LineRenderer line, Vector3 currentPos, Vector3 targetPos)
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

        float angle = 0;

        protected void RotateLaser(LineRenderer line, Vector2 currentPos, int right)
        {
            angle += 10f * Time.deltaTime * right;
            float rad = angle * Mathf.Deg2Rad;

            Vector2 dir = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            line.SetPosition(1, dir.normalized * 10f);
        }
    }
}

