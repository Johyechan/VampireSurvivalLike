using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    protected virtual void OnDisable()
    {

    }

    protected virtual void Update()
    {

    }

    protected bool CheckEnemyInArea(float radius)
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, Vector2.zero, 0, LayerMask.GetMask("Enemy", "Boss"));

        if (hit)
        {
            return true;
        }

        return false;
    }

    protected GameObject FindCloseEnemyInArea(float radius)
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.zero, 0, LayerMask.GetMask("Enemy", "Boss"));

        if (hits.Length <= 0)
            return null;

        float[] distances = new float[hits.Length];

        for (int i = 0; i < hits.Length; i++)
        {
            distances[i] = Vector2.Distance(transform.position, hits[i].collider.gameObject.transform.position);
        }

        float shortdistance = float.MaxValue;
        int numChecker = 0;

        for (int i = 0; i < distances.Length; i++)
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

    protected void FollowEnemy(ItemSO so, float speed = 1)
    {
        if (FindCloseEnemyInArea(so.range) == null)
            return;

        GameObject enemy = FindCloseEnemyInArea(so.range);
        Vector2 dir = (enemy.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotate = Quaternion.Euler(0, 0, angle - 90);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * speed);
    }
}
