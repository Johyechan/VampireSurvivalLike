using Enemy.Boss.Interface;
using Manager;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss
{
    public class BossAttackHandler
    {
        private BossBase _boss;

        public bool CanAttack { get; set; }
        public bool PatternEnd { get; set; }

        private float _attackDelay;

        public BossAttackHandler(BossBase boss, float attackDelay)
        {
            _boss = boss;
            _attackDelay = attackDelay;
        }

        public IEnumerator AttackDelayCo()
        {
            yield return new WaitForSeconds(_attackDelay);

            CanAttack = true;
            PatternEnd = false;

            while (!_boss.IsDead && !GameManager.Instance.gameOver)
            {
                if(!CanAttack)
                {
                    if (PatternEnd)
                    {
                        yield return new WaitForSeconds(_attackDelay);
                        CanAttack = true;
                        PatternEnd = false;
                    }
                    yield return null;
                }
                else
                {
                    yield return null;
                }
            }
        }
    }
}

