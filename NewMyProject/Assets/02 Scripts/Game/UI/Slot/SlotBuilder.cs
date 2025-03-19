using Manager;
using MyUI.Interface;
using MyUI.Strategy.Layout;
using MyUI.Strategy.Spawn;
using Player.Backpack;

namespace MyUI.Slot
{
    public class SlotBuilder : BuilderBase
    {
        private IUISpawnStrategy _spawnStrategy;
        private IUILayoutStrategy _layoutStrategy;

        private UICreator _creator;

        private PlayerBackpack _playerBackpack;

        private void Awake()
        {
            _spawnStrategy = new PoolUISpawnStrategy();
            _layoutStrategy = new GridLayoutStrategy();

            _creator = GetComponent<UICreator>();
            _creator.Init(_layoutStrategy, _spawnStrategy);
            
            _playerBackpack = GameManager.Instance.player.GetComponent<PlayerBackpack>();
        }

        private void Start()
        {
            _creator.CreateUI(_types, _parentTrans, _objXCount, _objYCount, _objWidth, _objHeight, _spacing, _playerBackpack.backpackSO.backpackArr);
        }
    }
}

