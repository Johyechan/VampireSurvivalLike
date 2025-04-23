using System;
using UnityEngine;

namespace MyUtil
{
    public static class AreaUtil
    {
        public static GameObject CheckArea(Transform trans, float range, int layerMask)
        {
            Collider2D hit = Physics2D.OverlapCircle(trans.position, range, layerMask);

            if(hit != null)
            {
                return hit.gameObject;
            }

            return null;
        }

        public static GameObject[] CheckAllArea(Transform trans, float range, int layerMask)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(trans.position, range, layerMask);

            if(hits.Length > 0)
            {
                GameObject[] objs = new GameObject[hits.Length];
                for(int i = 0; i < hits.Length; i++)
                {
                    objs[i] = hits[i].gameObject;
                }

                return objs;
            }

            return Array.Empty<GameObject>();
        }

        public static GameObject CheckCloseTargetInArea(Transform trans, float range, int layerMask)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(trans.position, range, layerMask);

            float distance = float.MaxValue;
            GameObject returnObj = null;

            foreach(var hit in hits)
            {
                float objDistance = Vector2.Distance(trans.position, hit.transform.position);
                if (distance > objDistance)
                {
                    distance = objDistance;
                    returnObj = hit.gameObject;
                }
            }

            return returnObj;
        }
    }
}
