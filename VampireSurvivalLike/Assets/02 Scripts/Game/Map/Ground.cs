using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class Ground : BaseMap
    {
        private Vector2 _lastPos;
        private Vector2 _curPos;

        [SerializeField] private float _changeScale;

        protected override void Start()
        {
            base.Start();
            _lastPos = transform.position;
        }

        protected override void Update()
        {
            base.Update();
            _curPos = GameManager.Instance.player.transform.position;
            if (Mathf.Abs(_curPos.x - _lastPos.x) > _changeScale)
            {
                _lastPos = MoveX(_curPos.x, _lastPos.x);
                GameManager.Instance.groundMove = true;
            }
            if (Mathf.Abs(_curPos.y - _lastPos.y) > _changeScale)
            {
                _lastPos = MoveY(_curPos.y, _lastPos.y);
                GameManager.Instance.groundMove = true;
            }
        }
    }
}

