using Enemy;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class EnemyDieState : IState
    {
        private EnemyMovement _movement;

        private ObjectPoolType _type;

        private GameObject _obj;

        public EnemyDieState(EnemyMovement movement, ObjectPoolType type, GameObject obj)
        {
            _movement = movement;
            _type = type;
            _obj = obj;
        }

        public void Enter()
        {
            _movement.StopImmediately();
            // �ӽ� ���� ��� �ִϸ��̼� �߰��ϰ� �ִϸ��̼� ������ �������� �ϱ�
            GameObject moneyObj = ObjectPoolManager.Instance.GetObject(ObjectPoolType.Money);
            moneyObj.transform.position = _obj.transform.position;
            ObjectPoolManager.Instance.ReturnObject(_type, _obj);
        }

        public void Execute()
        {
            
        }

        public void Exit()
        {
            
        }
    }
}

