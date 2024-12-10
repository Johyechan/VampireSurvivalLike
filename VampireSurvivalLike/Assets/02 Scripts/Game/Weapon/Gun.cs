using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pool;
using Manager;

namespace Weapon
{
    public class Gun : Shooter
    {
        protected override void Start()
        {
            base.Start();
            StartCoroutine(FireCo());
        }

        private IEnumerator FireCo()
        {
            while(true)
            {
                if(CheckEnemyInArea())
                {
                    Fire();
                    yield return new WaitForSeconds(_so.attackCoolTime);
                }
                else
                {
                    yield return null;
                }
            }
        }

        protected override void Fire()
        {
            // Hitter ����
            GameObject bullet = CreateHitter(ObjectPoolType.Bullet, _fireParent);
            bullet.transform.localPosition = _fireTrans.transform.position;
            // ����� �� ã��
            GameObject enemy = FindCloseEnemyInArea();
            // ����� ���� ���ϴ� ���� ã��
            Vector2 dir = (enemy.transform.position - bullet.transform.position).normalized;
            // �ѱ�, �Ѿ� ������
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
            transform.rotation = rotate;
            bullet.transform.rotation = transform.rotation;
            // Hitter ã�� �������� �߻�ӵ� ��ŭ ������
            Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();
            rigid2D.velocity = bullet.transform.up * _so.speed;
        }
    }
}

