
using System.Collections.Generic;
using MySO;
using MyStat;

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
        }

        public void RemoveItemStat(string itemName)
        {
            _itemStatMap.Remove(itemName);
            _totalItemStat = ItemTotalStat();
        }

        private ItemStat ItemTotalStat()
        {
            ItemStat stat = new ItemStat();

            foreach (var itemStat in _itemStatMap)
            {
                stat.attackDamage += itemStat.Value.attackDamage; // ���� ������
                stat.abilityPower += itemStat.Value.abilityPower; // ���� ������
                stat.soulPower += itemStat.Value.soulPower; // �ҿ� �Ŀ�?
                stat.range += itemStat.Value.range; // ���ݹ���
                stat.accuracyRate += itemStat.Value.accuracyRate; // ���߷� - Ȯ�� ����
                stat.avoidanceRate += itemStat.Value.avoidanceRate; // ȸ�Ƿ� - Ȯ�� ����
                stat.criticalHitRate += itemStat.Value.criticalHitRate; // ġ��Ÿ - Ȯ�� ����
                stat.attackSpeed += itemStat.Value.attackSpeed; // ���� - ���� ���� ����
                stat.speedIncrease += itemStat.Value.speedIncrease; // �̼� - ���� ���� ����
                stat.defence += itemStat.Value.defence; // ����
                stat.health += itemStat.Value.health; // ü��
                stat.mana += itemStat.Value.mana; // ����
                stat.soul += itemStat.Value.soul; // �ҿ�?
                stat.healingCost += itemStat.Value.healingCost; // ü�� �ڽ�Ʈ
                stat.manaCost += itemStat.Value.manaCost; // ���� �ڽ�Ʈ
                stat.healingSteal += itemStat.Value.healingSteal; // ���� - ���� ���� ����
                stat.manaSteal += itemStat.Value.manaSteal; // ���� ���� - ���� ���� ����
                stat.healingFactor += itemStat.Value.healingFactor; // ü��
                stat.manaFactor += itemStat.Value.manaFactor; // ������
            }

            return stat;
        }

        public void StatSet(PlayerSO so)
        {
            PlayerStat stat = new PlayerStat();

            stat.hp = so.hp; // ü��
            stat.hpRegen = so.hpRegen; // ü�� ���
            stat.damage = so.damage; // ������
            stat.mana = so.mana; // ����
            stat.defence = so.defence; // ����
            stat.avoidanceRate = so.avoidanceRate; // ȸ�Ƿ�
            stat.attackSpeed = so.attackSpeed; // ����
            stat.criticalHitRate = so.criticalHitRate; // ġ��Ÿ��
            stat.healingSteal = so.healingSteal; // ����
            stat.speed = so.speed; // �̼�

            _playerStat = stat;
        }

        public ItemStat StatSet(ItemSO so)
        {
            ItemStat stat = new ItemStat();

            stat.attackDamage = so.attackDamage; // ���� ������
            stat.abilityPower = so.abilityPower; // ���� ������
            stat.soulPower = so.soulPower; // �ҿ� �Ŀ�?
            stat.range = so.range; // ���ݹ���
            stat.accuracyRate = so.accuracyRate; // ���߷� - Ȯ�� ����
            stat.avoidanceRate = so.avoidanceRate; // ȸ�Ƿ� - Ȯ�� ����
            stat.criticalHitRate = so.criticalHitRate; // ġ��Ÿ - Ȯ�� ����
            stat.attackSpeed = so.attackSpeed; // ���� - ���� ���� ����
            stat.speedIncrease = so.speedIncrease; // �̼� - ���� ���� ����
            stat.defence = so.defence; // ����
            stat.health = so.health; // ü��
            stat.mana = so.mana; // ����
            stat.soul = so.soul; // �ҿ�?
            stat.healingCost = so.healingCost; // ü�� �ڽ�Ʈ
            stat.manaCost = so.manaCost; // ���� �ڽ�Ʈ
            stat.healingSteal = so.healingSteal; // ���� - ���� ���� ����
            stat.manaSteal = so.manaSteal; // ���� ���� - ���� ���� ����
            stat.healingFactor = so.healingFactor; // ü��
            stat.manaFactor = so.manaFactor; // ������

            return stat;
        }
    }
}

