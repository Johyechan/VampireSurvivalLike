using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    private PlayerController _controller;

    protected override void Start()
    {
        base.Start();

        _controller = GetComponent<PlayerController>();

        _isDie = false;

        _hp = _controller.so.hp;
    }

    protected override void Die()
    {
        death?.Invoke();
    }

    protected override void Death()
    {
        _isDie = true;
    }
}
