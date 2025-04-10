using Manager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public bool IsMoving { get { return _isMoving; } }
    private bool _isMoving = false;

    private Vector2 _moveInput;

    void Update()
    {
        transform.Translate(_moveInput * (StatManager.Instance.PlayerStat.speed + StatManager.Instance.AllStat.speedIncrease) * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        if(value.Get<Vector2>() != null)
        {
            _moveInput = value.Get<Vector2>();
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
