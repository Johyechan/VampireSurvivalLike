using Item.Interface;
using Item.Weapon;
using MyUtil.Interface;
using System.Collections;
using UnityEngine;

namespace Item.Strategy
{
    public class MeleeWeaponStrategy : IWeaponStrategy
    {
        private Transform _trans;

        private float _range;

        private string _layerMask;

        private WeaponItem _weapon;

        public MeleeWeaponStrategy(Transform trans, float range, string layerMask, WeaponItem weapon)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _weapon = weapon;
        }

        public void Attack()
        {
            GameObject enemy = CheckArea();
            if(enemy != null)
            {
                Vector2 dir = enemy.transform.position - _trans.position;
                float angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
                _trans.localRotation = Quaternion.Euler(0, 0, angle - 90);
                _weapon.StartCoroutine(AttackAnimation());
            }
        }

        public GameObject CheckArea()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(_trans.position, _range, LayerMask.GetMask(_layerMask));
            float distance = float.MaxValue;
            GameObject returnObj = null;

            if(hits.Length > 0)
            {
                for (int i = 0; i < hits.Length; i++)
                {
                    float checkDis = Vector2.Distance(_trans.position, hits[i].transform.position);
                    if (distance > checkDis)
                    {
                        distance = checkDis;
                        returnObj = hits[i].gameObject;
                    }
                }
            }

            return returnObj;
        }

        private IEnumerator AttackAnimation()
        {
            float curTime = 0;
            float animationTime = 0.2f;
            float z = _trans.localRotation.eulerAngles.z;
            Quaternion originRotation = Quaternion.Euler(0, 0, z);
            Quaternion targetRotation = Quaternion.Euler(0, 0, z + 45);

            while (curTime < animationTime)
            {
                curTime += Time.deltaTime;
                float t = Mathf.Clamp01(curTime / animationTime);
                _trans.localRotation = Quaternion.Lerp(originRotation, targetRotation, t);
                yield return null;
            }

            curTime = 0;
            originRotation = targetRotation;
            targetRotation = Quaternion.Euler(0, 0, z - 45);

            while(curTime < animationTime)
            {
                curTime += Time.deltaTime;
                float t = Mathf.Clamp01(curTime / animationTime);
                _trans.localRotation = Quaternion.Lerp(originRotation, targetRotation, t);
                yield return null;
            }

            curTime = 0;
            originRotation = targetRotation;
            targetRotation = Quaternion.Euler(0, 0, z);

            while (curTime < animationTime)
            {
                curTime += Time.deltaTime;
                float t = Mathf.Clamp01(curTime / animationTime);
                _trans.localRotation = Quaternion.Lerp(originRotation, targetRotation, t);
                yield return null;
            }

            _weapon.IsAttackEnd = true;
        }
    }
}