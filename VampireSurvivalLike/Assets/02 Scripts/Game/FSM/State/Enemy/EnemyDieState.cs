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
            // 임시 이후 사망 애니메이션 추가하고 애니메이션 끝나면 없어지게 하기
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

