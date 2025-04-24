using Enemy.Interface;
using MyUtil.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyUtil
{
    // 상태 전환을 처리 하는 클래스
    public class TransitionHandler
    {
        // 상태 전환을 처리하는 클래스들을 모아두는 리스트
        // 반복문을 통하여 각 상태 전환이 가능한지 판단할 예정
        private List<ITransition> _transitions = new();

        // 생성자를 통해 리스트를 주입 받아 초기화
        public TransitionHandler(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        // 리스트에 추가된 상태 전환을 처리하는 클래스들을 돌면서 상태 전환이 가능한지 판단
        // 상태 전환이 가능한 경우 true를 리턴
        public bool HandleTransitions()
        {
            foreach(ITransition transition in _transitions)
            {
                if (transition.TryTransitionToThisState())
                    return true;
            }

            return false;
        }
    }
}

