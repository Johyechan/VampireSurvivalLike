using Manager;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving { get { return _isMoving; } }
    private bool _isMoving = false;

    public Vector2 MoveInput { get { return _moveInput; } }
    private Vector2 _moveInput;

    private void OnMove(InputValue value)
    {
        if (value.Get<Vector2>() != null)
        {
            _moveInput = value.Get<Vector2>();
            GameManager.Instance.PlayerMoveDir = _moveInput;
            if (_moveInput != Vector2.zero)
            {
                _isMoving = true;
            }
            else
            {
                _isMoving = false;
            }
        }
    }
}
