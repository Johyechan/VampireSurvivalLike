using Inventory;
using Manager;
using MyUI;
using Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRerollButton : BaseButton
{
    [SerializeField] private InventoryMaker _maker;

    protected override void Start()
    {
        base.Start();
    }

    public override void OnCliked()
    {
        _maker.FillShopItem(true);
    }
}
