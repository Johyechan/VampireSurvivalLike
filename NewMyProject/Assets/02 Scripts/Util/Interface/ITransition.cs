using UnityEngine;

namespace MyUtil.Interface
{
    // 상태 전환을 처리하는 클래스들이 반드시 구현해야할 인터페이스
    public interface ITransition
    {
        // 상태 전환이 가능한지 판단하는 메서드
        public bool TryTransitionToThisState();
    }
}

