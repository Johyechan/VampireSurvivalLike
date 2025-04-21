using Item.Effect;
using Item.Effect.AllItem;
using Manager;
using MyUI.Item;
using UnityEngine;

namespace Item.Inventory
{
    public class Torch : InventoryItem
    {
        private Transform _weaponItemsParent;

        private FireEffect _fireEffect;

        private void Awake()
        {
            _weaponItemsParent = GameObject.Find("WeaponItems").transform;
            _fireEffect = new FireEffect(0.1f);
        }

        private void OnEnable()
        {
            if (transform.parent.name == "InventoryItems")
            {
                LightManager.Instance.MakePlayerLightBrighter(5, 10);
            }

            for(int i = 0; i < _weaponItemsParent.childCount; i++)
            {
                ItemEffectContainer container = _weaponItemsParent.GetChild(i).GetComponent<ItemBase>().EffectContainer;
                Debug.Log(_weaponItemsParent.GetChild(i));
                Debug.Log(container);
                container.AddEffect(_fireEffect);
            }
        }

        private void OnDisable()
        {
            if(LightManager.Instance != null)
                LightManager.Instance.ResetLightBrighter();
        }
    }
}

