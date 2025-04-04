using Manager;
using UnityEngine;

namespace Map
{
    public class Ground : MonoBehaviour
    {
        private Vector2 _playerPos;
        private Vector2 _latePos;

        [SerializeField] private float _changePosDistance;
        [SerializeField] private float _groundScale;

        void Start()
        {
            _latePos = transform.position;
        }

        void Update()
        {
            _playerPos = GameManager.Instance.player.transform.position;
            if (Mathf.Abs(_playerPos.x - _latePos.x) > _changePosDistance)
            {
                _latePos = MovePos(_playerPos.x, _latePos.x, true);
            }

            if(Mathf.Abs(_playerPos.y - _latePos.y) > _changePosDistance)
            {
                _latePos = MovePos(_playerPos.y, _latePos.y, false);
            }
        }

        private Vector2 MovePos(float playerValue, float lateValue, bool isX)
        {
            float value = playerValue - lateValue > 0 ? 1 : -1;

            if(isX)
            {
                transform.Translate(new Vector2(value, 0) * _groundScale * 2);
            }
            else
            {
                transform.Translate(new Vector2(0, value) * _groundScale * 2);
            }

            return transform.position;
        }
    }
}

