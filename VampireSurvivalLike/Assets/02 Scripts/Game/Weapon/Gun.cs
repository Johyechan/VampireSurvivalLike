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
            // Hitter 생성
            GameObject bullet = CreateHitter(ObjectPoolType.Bullet, _fireParent);
            bullet.transform.localPosition = _fireTrans.transform.position;
            // 가까운 적 찾기
            GameObject enemy = FindCloseEnemyInArea();
            // 가까운 적을 향하는 방향 찾기
            Vector2 dir = (enemy.transform.position - bullet.transform.position).normalized;
            // 총구, 총알 돌리기
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
            transform.rotation = rotate;
            bullet.transform.rotation = transform.rotation;
            // Hitter 찾은 방향으로 발사속도 만큼 날리기
            Rigidbody2D rigid2D = bullet.GetComponent<Rigidbody2D>();
            rigid2D.velocity = bullet.transform.up * _so.speed;
        }
    }
}

