using Pool;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Weapon
{
    public abstract class Shooter : MonoBehaviour
    {
        [SerializeField] protected WeaponSO _so;

        [SerializeField] protected Transform _fireTrans;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, _so.radius);
        }

        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {

        }

        protected GameObject CreateHitter(ObjectPoolType type, Transform trans)
        {
            GameObject obj = ObjectPoolManager.Instance.GetObject(type, trans);

            Hitter hitter = obj.GetComponent<Hitter>();
            hitter.Damage = _so.power;

            return obj;
        }

        protected GameObject FindCloseEnemyInArea()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _so.radius, Vector2.zero, 0, LayerMask.GetMask("Enemy", "Boss"));

            float[] distances = new float[hits.Length];

            for(int i = 0; i < hits.Length; i++)
            {
                distances[i] = Vector2.Distance(_fireTrans.position, hits[i].collider.gameObject.transform.position);
            }

            float shortdistance = float.MaxValue;
            int numChecker = 0;

            for(int i = 0; i < distances.Length; i++)
            {
                float temp = shortdistance;
                shortdistance = Mathf.Min(shortdistance, distances[i]);
                if (temp != shortdistance)
                {
                    numChecker = i;
                }
            }

            return hits[numChecker].collider.gameObject;
        }

        protected abstract void Fire();
    }
}

