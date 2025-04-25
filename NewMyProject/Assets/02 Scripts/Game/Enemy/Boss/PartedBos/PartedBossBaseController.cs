using Enemy.Boss.Interface;
using MyUtil.FSM;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

namespace Enemy.Boss.PartedBoss
{
    public class PartedBossBaseController : MonoBehaviour
    {
        [SerializeField] private List<IBossPart> _parts = new();

        // 트랜지션 사용해야 함

        protected StateMachine _machine;

        protected IState _idleState;
        protected IState _attackState;
        protected IState _deathState;

        private int _deathCount;

        protected virtual void Awake()
        {
            _machine = new StateMachine();
            _deathCount = 0;
        }

        protected virtual void Update()
        {
            foreach(var part in _parts)
            {
                if(part.IsDestroy)
                {
                    _deathCount++;
                }
            }
        }
    }
}

