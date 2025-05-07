using Enemy.Boss.Interface;
using Enemy.Boss.PartedBoss;
using MyUtil.Interface;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy.Boss.Pattern
{
    public abstract class LaserPattern : PatternBase
    {
        protected LaserPattern(BossPartBase currentPart, BossAttackHandler attackHandler) : base(currentPart, attackHandler)
        {
        }

        protected void CreateLaser(LineRenderer line, Vector3 startPos, Vector3 endPos, float width, Color color, float length)
        {
            line.startColor = color;
            line.startWidth = width;
            line.SetPosition(0, startPos);
            line.SetPosition(1, startPos + endPos * length);
            line.endWidth = width;
            line.endColor = color;
        }

        protected void CreateRay(LineRenderer line, float width, float length, int interval, float damage)
        {
            // ���̸� �� ������ ����
            Vector2 dir = (line.GetPosition(1) - line.GetPosition(0)).normalized;
            // ���� �ȿ� interval ���� ���̵鸦 �ʺ� / ���� ��ŭ�� ������ �ΰ� ��
            for (float i = -width / 2; i < width / 2; i += interval / width)
            {
                // ������ �ΰ� ���� ���� ������ ���� ��� ���ؼ��� x������ ������ ��ŭ y���� �ݴ�� x���� ������ ��ŭ�� ���ݸ� �������� ��
                RaycastHit2D hit = Physics2D.Raycast(line.GetPosition(0) + new Vector3(i, -(i / 2)), dir, length, LayerMask.GetMask("Player"));

                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                        // �������̱� ������ ���������� ���ظ� �ְ� �ǰ� �׷��� �������� ����
                        damageable.TakeDamage(damage / 1000);
                        break;
                    }
                }
            }
            
        }

        protected int GetLaserMoveDirection(LineRenderer line, Vector3 currentPos, Vector3 targetPos)
        {
            float cross = currentPos.x * targetPos.y - targetPos.x * currentPos.y;

            if(cross < 0)
            {
                // ������
                return -1;
            }
            else
            {
                // ����
                return 1;
            }
        }

        protected IEnumerator RotateLaser(LineRenderer line, Vector2 currentPos, float rotateSpeed, float length, float rotateTime, int rotateDir)
        {
            float angle = 0;
            float curTime = 0;
            Vector2 startPos = line.GetPosition(0);

            while(curTime < rotateTime)
            {
                curTime += Time.deltaTime;
                angle += rotateSpeed * Time.deltaTime * rotateDir;
                float rad = angle * Mathf.Deg2Rad;

                Vector2 rotatedDir = new Vector2(
                    currentPos.x * Mathf.Cos(rad) - currentPos.y * Mathf.Sin(rad),
                    currentPos.x * Mathf.Sin(rad) + currentPos.y * Mathf.Cos(rad)
                );

                line.SetPosition(1, startPos + rotatedDir * length);

                CreateRay(line, line.startWidth, length, 5, _currentPart.Damage);

                yield return null;
            }
        }
    }
}

