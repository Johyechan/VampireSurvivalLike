using Item.Interface;
using Item.Weapon;
using Item.Weapon.Melee;
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

        private MeleeWeapon _weapon;

        public MeleeWeaponStrategy(Transform trans, float range, string layerMask, MeleeWeapon weapon)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _weapon = weapon;
        }

        public void Attack()
        {
            GameObject enemy = _weapon.CheckArea(_trans, _range, _layerMask);
            if(enemy != null)
            {
                _weapon.StartCoroutine(AttackAnimation());
            }
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

            _weapon.OnDamage();

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