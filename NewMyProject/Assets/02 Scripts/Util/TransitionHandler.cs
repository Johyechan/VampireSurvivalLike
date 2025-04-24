using Enemy.Interface;
using MyUtil.Interface;
using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace MyUtil
{
    // ���� ��ȯ�� ó�� �ϴ� Ŭ����
    public class TransitionHandler
    {
        // ���� ��ȯ�� ó���ϴ� Ŭ�������� ��Ƶδ� ����Ʈ
        // �ݺ����� ���Ͽ� �� ���� ��ȯ�� �������� �Ǵ��� ����
        private List<ITransition> _transitions = new();

        // �����ڸ� ���� ����Ʈ�� ���� �޾� �ʱ�ȭ
        public TransitionHandler(List<ITransition> transitions)
        {
            _transitions = transitions;
        }

        // ����Ʈ�� �߰��� ���� ��ȯ�� ó���ϴ� Ŭ�������� ���鼭 ���� ��ȯ�� �������� �Ǵ�
        // ���� ��ȯ�� ������ ��� true�� ����
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

