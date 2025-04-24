using Enemy.Interface;
using Enemy.Interface.Strategy;
using MyUtil.Interface;
using UnityEngine;

namespace Enemy.Strategy.Attack
{
    // �⺻������ �� ���ݿ� �ʿ��� �͵��� ������ Ŭ����
    public abstract class EnemyAttackStrategyBase : IEnemyAttackStrategy
    {
        // ������ �������̽��� �ݵ�� �����ϵ��� �߻� �޼���� ����
        public abstract void Attack();

        public abstract bool CheckArea();
    }
}

