using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextUI : MonoBehaviour, IEventListener<int>
{
    private MoneyEvent _onMoneyUsed;
    private TMP_Text _tmpText;

    private void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _onMoneyUsed.AddEvent(this);
    }

    private void OnDisable()
    {
        _onMoneyUsed.RemoveEvent(this);
    }

    public void OnEvent(int t)
    {
        _tmpText.text = "X " + t.ToString();
    }
}
