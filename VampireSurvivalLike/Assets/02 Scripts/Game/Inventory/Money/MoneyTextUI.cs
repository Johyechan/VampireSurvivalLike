using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextUI : MonoBehaviour, IEventListener<int>
{
    private TMP_Text _tmpText;

    private void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        GameEventManager.OnMoneyUIEvent.AddEvent(this);
    }

    private void OnDisable()
    {
        GameEventManager.OnMoneyUIEvent.RemoveEvent(this);
    }

    public void OnEvent(int t)
    {
        _tmpText.text = "X " + t.ToString();
    }
}
