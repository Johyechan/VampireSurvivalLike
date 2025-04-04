using Manager;
using Manager.UI;
using TMPro;
using UnityEngine;

public class StatText : MonoBehaviour
{
    [SerializeField] private TMP_Text attackDamage;
    [SerializeField] private TMP_Text abilityPower;
    [SerializeField] private TMP_Text soulPower;
    [SerializeField] private TMP_Text accuracyRate;
    [SerializeField] private TMP_Text avoidanceRate;
    [SerializeField] private TMP_Text criticalHitRate;
    [SerializeField] private TMP_Text attackSpeed;
    [SerializeField] private TMP_Text speedIncrease;
    [SerializeField] private TMP_Text defence;
    [SerializeField] private TMP_Text health;
    [SerializeField] private TMP_Text mana;
    [SerializeField] private TMP_Text soul;
    [SerializeField] private TMP_Text healingCost;
    [SerializeField] private TMP_Text manaCost;
    [SerializeField] private TMP_Text healingSteal;
    [SerializeField] private TMP_Text manaSteal;
    [SerializeField] private TMP_Text healingFactor;
    [SerializeField] private TMP_Text manaFactor;

    void Start()
    {
        attackDamage.text = $"Attack damage: {StatManager.Instance.AllStat.attackDamage}";
        abilityPower.text = $"Ability power: {StatManager.Instance.AllStat.abilityPower}";
        soulPower.text = $"Soul power: {StatManager.Instance.AllStat.soulPower}";
        accuracyRate.text = $"Accuracy rate: {StatManager.Instance.AllStat.accuracyRate}";
        avoidanceRate.text = $"Avoidance rate: {StatManager.Instance.AllStat.avoidanceRate}";
        criticalHitRate.text = $"Critical hit rate: {StatManager.Instance.AllStat.criticalHitRate}";
        attackSpeed.text = $"Attack speed: {StatManager.Instance.AllStat.attackSpeed}";
        speedIncrease.text = $"Speed increase: {StatManager.Instance.AllStat.speedIncrease}";
        defence.text = $"Defence: {StatManager.Instance.AllStat.defence}";
        health.text = $"Health: {StatManager.Instance.AllStat.health}";
        mana.text = $"Mana: {StatManager.Instance.AllStat.mana}";
        soul.text = $"Soul: {StatManager.Instance.AllStat.soul}";
        healingCost.text = $"Healing cost: {StatManager.Instance.AllStat.healingCost}";
        manaCost.text = $"Mana cost: {StatManager.Instance.AllStat.manaCost}";
        healingSteal.text = $"Healing steal: {StatManager.Instance.AllStat.healingSteal}";
        manaSteal.text = $"Mana steal: {StatManager.Instance.AllStat.manaSteal}";
        healingFactor.text = $"Healing factor: {StatManager.Instance.AllStat.healingFactor}";
        manaFactor.text = $"Mana factor: {StatManager.Instance.AllStat.manaFactor}";
    }
}
