using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    public static MoneyUIEvent OnMoneyUIEvent = new MoneyUIEvent();

    public static MoneyUseEvent OnMoneyUseEvent = new MoneyUseEvent();
}
