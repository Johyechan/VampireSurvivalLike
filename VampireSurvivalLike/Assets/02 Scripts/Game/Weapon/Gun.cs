using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapon
{
    public class Gun : Shooter
    {
        protected override void Start()
        {
            base.Start();
        }

        protected override void Update()
        {
            base.Update();
        }

        protected override void Fire()
        {
            // Hitter 생성
            // 가까운 적 찾기
            // 가까운 적을 향하는 방향 찾기
            // Hitter 찾은 방향으로 발사속도 만큼 날리기
            // 쿨타임 기다리기
        }
    }
}

