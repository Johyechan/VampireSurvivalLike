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

        public void ChangeItemStat(ItemSO so, int isPlus = 1)
        {
            _allStat.attackDamage += so.attackDamage * isPlus;
            _allStat.abilityPower += so.abilityPower * isPlus;
            _allStat.soulPower += so.soulPower * isPlus;
            _allStat.accuracyRate += so.accuracyRate * isPlus;
            _allStat.avoidanceRate += so.avoidanceRate * isPlus;
            _allStat.criticalHitRate += so.criticalHitRate * isPlus;
            _allStat.attackSpeed += so.attackSpeed * isPlus;
            _allStat.speedIncrease += so.speedIncrease  * isPlus;
            _allStat.defence += so.defence * isPlus;
            _allStat.health += so.health * isPlus; // ü��
            _allStat.mana += so.mana * isPlus; // ����
            _allStat.soul += so.soul * isPlus; // �ҿ�?
            _allStat.healingCost += so.healingCost * isPlus; // ü�� �ڽ�Ʈ
            _allStat.manaCost += so.manaCost * isPlus; // ���� �ڽ�Ʈ
            _allStat.healingSteal += so.healingSteal * isPlus; // ���� - ���� ���� ����
            _allStat.manaSteal += so.manaSteal * isPlus; // ���� ���� - ���� ���� ����
            _allStat.healingFactor += so.healingFactor * isPlus; // ü��
            _allStat.manaFactor += so.manaFactor * isPlus; // ������
        }
    }
}

