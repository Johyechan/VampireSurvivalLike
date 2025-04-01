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
            _allStat.health += so.health; // 체력
            _allStat.mana += so.mana; // 마나
            _allStat.soul += so.soul; // 소울?
            _allStat.healingCost += so.healingCost; // 체력 코스트
            _allStat.manaCost += so.manaCost; // 마나 코스트
            _allStat.healingSteal += so.healingSteal; // 피흡 - 비율 증감 계산기
            _allStat.manaSteal += so.manaSteal; // 마나 흡혈 - 비율 증감 계산기
            _allStat.healingFactor += so.healingFactor; // 체젠
            _allStat.manaFactor += so.manaFactor; // 마나젠
        }
    }
}

