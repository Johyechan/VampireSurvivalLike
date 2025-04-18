using Manager.UI;
using MyFactory.Interface;
using MyUI.Item;
using MyUI.Struct;
using MyUtil.Pool;
using UnityEngine;

namespace MyFactory
{
    public class UIItemFactory : IFactory
    {
        private GameObject _obj;

        private ItemShape _shape;

        private Vector2 _shopOriginPos;

        public GameObject CreateObj(ObjectPoolType type, Vector2 shopOriginPos, Transform transform = null)
        {
            GameObject uiItem = ObjectPoolManager.Instance.GetObject(type, transform);

            _obj = uiItem;
            _shape = uiItem.GetComponent<UIItem>().uiItemSO.DeepCopy().shape;
            _shopOriginPos = shopOriginPos;

            Init();

            return uiItem;
        }

        public void Init()
        {
            if (UIItemManager.Instance.UIItemInformations.ContainsKey(_obj.name))
            {
                var baseInformation = UIItemManager.Instance.UIItemInformations[_obj.name];

                UIItemFSMInformation _information = new UIItemFSMInformation()
                {
                    idleState = baseInformation.idleState,
                    placementSuccessState = baseInformation.placementSuccessState,
                    placementFailedState = baseInformation.placementFailedState,
                    draggingState = baseInformation.draggingState,
                    salesState = baseInformation.salesState,

                    parent = _obj.transform.parent,
                    originPosition = _shopOriginPos,
                    originRotaiton = _obj.GetComponent<RectTransform>().rotation,

                    shape = _shape.ShapeDeepCopy()
                };

                UIItemManager.Instance.UIItemInformations[_obj.name] = _information;
            }
        }
    }
}

