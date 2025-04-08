using UnityEngine;

namespace Enemy.Interface
{
    public interface IEnemyMoveStrategy
    {
        public bool CheckArea(Transform trans, float range, string layerMask);

        public void Move(Transform trans, Vector2 dir, float speed);
    }
}

