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
            _isMoving = true;
            _moveInput = value.Get<Vector2>();
        }
        else
        {
            _isMoving = false;
        }
    }
}
