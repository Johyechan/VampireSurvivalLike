using MyUI.Interface;
using MyUI.Strategy.Layout;
using MyUI.Strategy.Spawn;

namespace MyUI.Shop
{
    public class ShopBuilder : BuilderBase
    {
        private IUILayoutStrategy _layoutStrategy;
        private IUISpawnStrategy _spawnStrategy;

        private UICreator _creator;

        private void Awake()
        {
            _layoutStrategy = new GridLayoutStrategy();
            _spawnStrategy = new PoolUISpawnStrategy();

            _creator = GetComponent<UICreator>();
            _creator.Init(_layoutStrategy, _spawnStrategy);
        }

        void Start()
        {
            _creator.CreateUI(_types, _parentTrans, _objXCount, _objYCount, _objWidth, _objHeight, _spacing);
        }
    }
}

