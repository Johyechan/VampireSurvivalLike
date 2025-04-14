using Enemy.Interface;
using Enemy.Interface.Strategy;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    // 플레이어를 따라다니는 움직임
    public class EnemyPlayerFollowMove : IEnemyMoveStrategy
    {
        private Transform _trans;
        private Transform _targetTrans;

        private Vector2 _dir;

        private float _range;
        private float _speed;

        private string _layerMask;

        public EnemyPlayerFollowMove(Transform trans, Transform targetTrans, float range, float speed, string layerMask)
        {
            _trans = trans;
            _targetTrans = targetTrans;
            _range = range;
            _speed = speed;
            _layerMask = layerMask;
        }

        public bool CheckArea()
        {
            // 일정 원형 범위 내 플레이어 찾기
            Collider2D hit = Physics2D.OverlapCircle(_trans.position, _range, LayerMask.GetMask(_layerMask));

            // 찾았다면 true를 반환
            if(hit != null)
            {
                return true;
            }

            // 찾지 못했다면 false를 반환
            return false;
        }

        public void Move()
        {
            _dir = _targetTrans.position - _trans.position;

            // trans를 dir 방향으로 speed의 속도로 움직임
            _trans.Translate(_dir.normalized * _speed * Time.deltaTime);
        }
    }
}

