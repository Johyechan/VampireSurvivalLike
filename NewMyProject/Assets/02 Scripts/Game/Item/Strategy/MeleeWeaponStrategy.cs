using Item.Interface;
using MyUtil.Interface;
using UnityEngine;

namespace Item.Strategy
{
    public class MeleeWeaponStrategy : IWeaponStrategy
    {
        private Transform _trans;

        private float _range;

        private string _layerMask;

        private Animator _animator;

        private int _hash;

        public MeleeWeaponStrategy(Transform trans, float range, string layerMask, Animator animator, int hash)
        {
            _trans = trans;
            _range = range;
            _layerMask = layerMask;
            _animator = animator;
            _hash = hash;
        }

        public void Attack()
        {
            GameObject enemy = CheckArea();
            if(enemy != null)
            {
                _animator.SetBool(_hash, true);
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
    }
}