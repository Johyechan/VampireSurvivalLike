using Manager;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _moveInput;

    void Update()
    {
        transform.Translate(_moveInput * (StatManager.Instance.PlayerStat.speed + StatManager.Instance.AllStat.speedIncrease) * Time.deltaTime);
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<Vector2>();
    }
}
