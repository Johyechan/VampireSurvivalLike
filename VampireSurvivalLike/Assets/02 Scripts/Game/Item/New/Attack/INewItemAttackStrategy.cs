using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INewItemAttackStrategy
{
    public void Attack(ItemSO so, INewEffect effect);
}
