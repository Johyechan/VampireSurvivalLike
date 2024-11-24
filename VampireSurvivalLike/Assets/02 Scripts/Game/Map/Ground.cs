using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map
{
    public class Ground : MonoBehaviour
    {
        private Vector2 _lastPos;
        private Vector2 _curPos;

        [SerializeField] private float _changeScale;

        private void Start()
        {
            _lastPos = transform.position;
        }

        private void Update()
        {
            _curPos = GameManager.Instance.player.transform.position;
            if (Mathf.Abs(_curPos.x - _lastPos.x) > _changeScale)
            {
                MoveGroundX();
            }
            if (Mathf.Abs(_curPos.y - _lastPos.y) > _changeScale)
            {
                MoveGroundY();
            }
        }

        private void MoveGroundX()
        {
            int x = (_curPos.x - _lastPos.x > 0) ? 1 : -1;

            transform.Translate(new Vector3(x, 0) * 100);

            _lastPos = transform.position;
        }

        private void MoveGroundY()
        {
            int y = (_curPos.y - _lastPos.y > 0) ? 1 : -1;

            transform.Translate(new Vector3(0, y) * 100);

            _lastPos = transform.position;
        }
    }
}

