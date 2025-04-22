using Manager;
using MyUtil.Interface;
using MyUtil.Pool;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace MyUtil
{
    public abstract class ProjectileBase : MonoBehaviour
    {
        [SerializeField] protected ObjectPoolType _type;

        [SerializeField] private float _destroyDelayTime;

        public float FireSpeed { get; set; }
        public float Damage { get; set; }

        public Vector2 Direction { get; set; }

        private void OnEnable()
        {
            StartCoroutine(DestroyProjectile());
        }

        private void OnDisable()
        {
            StopCoroutine(DestroyProjectile());
        }

        private void Update()
        {
            transform.position += (Vector3)(Direction.normalized * FireSpeed * Time.deltaTime);
        }

        private IEnumerator DestroyProjectile()
        {
            yield return new WaitForSeconds(_destroyDelayTime);
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }

        protected abstract void OnTriggerEnter2D(Collider2D collision);
    }
}

