
using System.Collections.Generic;
using MySO;
using MyStat;
using UnityEngine;

namespace Manager
{
    public class StatManager : MonoSingleton<StatManager>
    {
        private PlayerStat _playerStat = new PlayerStat();
        public PlayerStat PlayerStat { get { return _playerStat; } }

        private ItemStat _totalItemStat = new ItemStat();
        public ItemStat TotalItemStat { get { return _totalItemStat; } set { _totalItemStat = value; } }

        private Dictionary<string, ItemStat> _itemStatMap = new Dictionary<string, ItemStat>();

        protected override void Awake()
        {
            base.Awake();
        }

        public void AddItemStat(string itemName, ItemStat stat)
        {
            _itemStatMap.Add(itemName, stat);
            _totalItemStat = ItemTotalStat();
            //Debug.Log(_totalItemStat.attackDamage);
            //Debug.Log(_totalItemStat.abilityPower);
            //Debug.Log(_totalItemStat.soulPower);
            //Debug.Log(_totalItemStat.range);
            //Debug.Log(_totalItemStat.accuracyRate);
            //Debug.Log(_totalItemStat.avoidanceRate);
            //Debug.Log(_totalItemStat.criticalHitRate);
            //Debug.Log(_totalItemStat.attackSpeed);
            //Debug.Log(_totalItemStat.speedIncrease);
            //Debug.Log(_totalItemStat.defence);
            //Debug.Log(_totalItemStat.health);
            //Debug.Log(_totalItemStat.mana);
            //Debug.Log(_totalItemStat.soul);
            //Debug.Log(_totalItemStat.healingCost);
            //Debug.Log(_totalItemStat.manaCost);
            //Debug.Log(_totalItemStat.healingSteal);
            //Debug.Log(_totalItemStat.manaSteal);
            //Debug.Log(_totalItemStat.healingFactor);
            //Debug.Log(_totalItemStat.manaFactor);
        }

        public bool FindItemStat(string itemName)
        {
            if(_itemStatMap.ContainsKey(itemName))
            {
                return true;
            }

            return false;
        }

        public void RemoveItemStat(string itemName)
        {
            _itemStatMap.Remove(itemName);
            _totalItemStat = ItemTotalStat();
            //Debug.Log(_totalItemStat.attackDamage);
            //Debug.Log(_totalItemStat.abilityPower);
            //Debug.Log(_totalItemStat.soulPower);
            //Debug.Log(_totalItemStat.range);
            //Debug.Log(_totalItemStat.accuracyRate);
            //Debug.Log(_totalItemStat.avoidanceRate);
            //Debug.Log(_totalItemStat.criticalHitRate);
            //Debug.Log(_totalItemStat.attackSpeed);
            //Debug.Log(_totalItemStat.speedIncrease);
            //Debug.Log(_totalItemStat.defence);
            //Debug.Log(_totalItemStat.health);
            //Debug.Log(_totalItemStat.mana);
            //Debug.Log(_totalItemStat.soul);
            //Debug.Log(_totalItemStat.healingCost);
            //Debug.Log(_totalItemStat.manaCost);
            //Debug.Log(_totalItemStat.healingSteal);
            //Debug.Log(_totalItemStat.manaSteal);
            //Debug.Log(_totalItemStat.healingFactor);
            //Debug.Log(_totalItemStat.manaFactor);
        }

        private ItemStat ItemTotalStat()
        {
            ItemStat stat = new ItemStat();

            foreach (var itemStat in _itemStatMap)
            {
                stat.attackDamage += itemStat.Value.attackDamage; // 물리 데미지
                stat.abilityPower += itemStat.Value.abilityPower; // 마법 데미지
                stat.soulPower += itemStat.Value.soulPower; // 소울 파워
                stat.range += itemStat.Value.range; // 공격범위
                stat.accuracyRate += itemStat.Value.accuracyRate; // 명중률 - 확률 계산기
                stat.avoidanceRate += itemStat.Value.avoidanceRate; // 회피률 - 확률 계산기
                stat.criticalHitRate += itemStat.Value.criticalHitRate; // 치명타 - 확률 계산기
                stat.attackSpeed += itemStat.Value.attackSpeed; // 공속 - 비율 증감 계산기
                stat.speedIncrease += itemStat.Value.speedIncrease; // 이속 - 비율 증감 계산기
                stat.defence += itemStat.Value.defence; // 방어력
                stat.health += itemStat.Value.health; // 체력
                stat.mana += itemStat.Value.mana; // 마나
                stat.soul += itemStat.Value.soul; // 소울
                stat.healingCost += itemStat.Value.healingCost; // 체력 코스트
                stat.manaCost += itemStat.Value.manaCost; // 마나 코스트
                stat.healingSteal += itemStat.Value.healingSteal; // 피흡 - 비율 증감 계산기
                stat.manaSteal += itemStat.Value.manaSteal; // 마나 흡혈 - 비율 증감 계산기
                stat.healingFactor += itemStat.Value.healingFactor; // 체젠
                stat.manaFactor += itemStat.Value.manaFactor; // 마나젠
            }

            return stat;
        }

        public void SetStat(PlayerSO so)
        {
            PlayerStat stat = new PlayerStat();

            stat.hp = so.hp; // 체력
            stat.hpRegen = so.hpRegen; // 체력 재생
            stat.damage = so.damage; // 데미지
            stat.mana = so.mana; // 마나
            stat.defence = so.defence; // 방어력
            stat.avoidanceRate = so.avoidanceRate; // 회피률
            stat.attackSpeed = so.attackSpeed; // 공속
            stat.criticalHitRate = so.criticalHitRate; // 치명타률
            stat.healingSteal = so.healingSteal; // 흡혈
            stat.speed = so.speed; // 이속

            _playerStat = stat;
        }

        public ItemStat SetStat(ItemSO so)
        {
            ItemStat stat = new ItemStat();

            stat.attackDamage = so.attackDamage; // 물리 데미지
            stat.abilityPower = so.abilityPower; // 마법 데미지
            stat.soulPower = so.soulPower; // 소울 파워?
            stat.range = so.range; // 공격범위
            stat.accuracyRate = so.accuracyRate; // 명중률 - 확률 계산기
            stat.avoidanceRate = so.avoidanceRate; // 회피률 - 확률 계산기
            stat.criticalHitRate = so.criticalHitRate; // 치명타 - 확률 계산기
            stat.attackSpeed = so.attackSpeed; // 공속 - 비율 증감 계산기
            stat.speedIncrease = so.speedIncrease; // 이속 - 비율 증감 계산기
            stat.defence = so.defence; // 방어력
            stat.health = so.health; // 체력
            stat.mana = so.mana; // 마나
            stat.soul = so.soul; // 소울?
            stat.healingCost = so.healingCost; // 체력 코스트
            stat.manaCost = so.manaCost; // 마나 코스트
            stat.healingSteal = so.healingSteal; // 피흡 - 비율 증감 계산기
            stat.manaSteal = so.manaSteal; // 마나 흡혈 - 비율 증감 계산기
            stat.healingFactor = so.healingFactor; // 체젠
            stat.manaFactor = so.manaFactor; // 마나젠

            return stat;
        }
    }
}

