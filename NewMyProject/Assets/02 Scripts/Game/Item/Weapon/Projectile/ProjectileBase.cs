using Manager;
using MyUtil.Interface;
using MyUtil.Pool;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private ObjectPoolType _type;

    [SerializeField] private float _destroyDelayTime;

    private Rigidbody2D _rigid2D;

    public float FireSpeed { get; set; }
    public float Damage { get; set; }

    public Vector2 Direction { get; set; }

    private void Awake()
    {
        _rigid2D = GetComponent<Rigidbody2D>();
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();
            damageable.TakeDamage(Damage);
            ObjectPoolManager.Instance.ReturnObj(_type, gameObject);
        }
    }
}
