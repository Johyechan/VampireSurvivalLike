using Enemy.Interface;
using Enemy.Interface.Strategy;
using MyUtil;
using UnityEngine;

namespace Enemy.Strategy.Move
{
    // �÷��̾ ����ٴϴ� ������
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
            GameObject player = AreaUtil.CheckArea(_trans, _range, LayerMask.GetMask(_layerMask));

            if (player != null)
                return true;

            return false;
        }

        public void Move()
        {
            _dir = _targetTrans.position - _trans.position;

            // trans�� dir �������� speed�� �ӵ��� ������
            _trans.Translate(_dir.normalized * _speed * Time.deltaTime);
        }
    }
}

