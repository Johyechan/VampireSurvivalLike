using System.Collections;
using UnityEngine;

namespace Enemy.Boss
{
    public class BossAttackHandler
    {
        public bool CanAttack { get; set; }
        public bool PatternEnd { get; set; }

        private float _attackDelay;

        public BossAttackHandler(float  attackDelay)
        {
            _attackDelay = attackDelay;
        }

        public IEnumerator AttackDelayCo()
        {
            yield return new WaitForSeconds(_attackDelay);

            CanAttack = true;

            while(true)
            {
                if(!CanAttack)
                {
                    PatternEnd = false;
                    if (PatternEnd)
                    {
                        yield return new WaitForSeconds(_attackDelay);
                        CanAttack = true;
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

