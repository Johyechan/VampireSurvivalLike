using UnityEngine;

namespace MyUtil.Interface
{
    // ���� ��ȯ�� ó���ϴ� Ŭ�������� �ݵ�� �����ؾ��� �������̽�
    public interface ITransition
    {
        // ���� ��ȯ�� �������� �Ǵ��ϴ� �޼���
        public bool TryTransitionToThisState();
    }
}

