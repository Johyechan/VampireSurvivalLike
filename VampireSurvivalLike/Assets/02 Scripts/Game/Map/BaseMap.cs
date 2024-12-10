using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class BaseMap : MonoBehaviour
    {
        protected virtual void Start()
        {
            
        }

        protected virtual void Update()
        {

        }

        protected Vector2 MoveX(float curPosX, float lastPosX)
        {
            int x = (curPosX - lastPosX > 0) ? 1 : -1;

            transform.Translate(new Vector3(x, 0) * 100);

            return transform.position;
        }

        protected Vector2 MoveY(float curPosY, float lastPosY)
        {
            int y = (curPosY - lastPosY > 0) ? 1 : -1;

            transform.Translate(new Vector3(0, y) * 100);

            return transform.position;
        }
    }
}

