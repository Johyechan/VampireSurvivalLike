using Item.Stat;
using MyUtil;
using Player;
using UnityEngine;

namespace Manager
{
    public class StatManager : Singleton<StatManager>
    {
        public ItemStat AllStat { get { { return _allStat; } } }
        private ItemStat _allStat;

        public PlayerSO PlayerStat { get { return _playerSO; } }
        private PlayerSO _playerSO;

        protected override void Awake()
        {
            base.Awake();

            _playerSO = GameManager.Instance.player.GetComponent<PlayerController>().playerSO;
            _allStat = new ItemStat();
        }

        public void AddItemStat(ItemSO so)
        {
            _allStat.attackDamage += so.attackDamage;
            _allStat.abilityPower += so.abilityPower;
            _allStat.soulPower += so.soulPower;
            _allStat.accuracyRate += so.accuracyRate;
            _allStat.avoidanceRate += so.avoidanceRate;
            _allStat.criticalHitRate += so.criticalHitRate;
            _allStat.attackSpeed += so.attackSpeed;
            _allStat.speedIncrease += so.speedIncrease;
            _allStat.defence += so.defence;
            _allStat.health += so.health; // ü��
            _allStat.mana += so.mana; // ����
            _allStat.soul += so.soul; // �ҿ�?
            _allStat.healingCost += so.healingCost; // ü�� �ڽ�Ʈ
            _allStat.manaCost += so.manaCost; // ���� �ڽ�Ʈ
            _allStat.healingSteal += so.healingSteal; // ���� - ���� ���� ����
            _allStat.manaSteal += so.manaSteal; // ���� ���� - ���� ���� ����
            _allStat.healingFactor += so.healingFactor; // ü��
            _allStat.manaFactor += so.manaFactor; // ������
        }
    }
}

