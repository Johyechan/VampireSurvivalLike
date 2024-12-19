using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player", order = 0)]
public class PlayerSO : ScriptableObject
{
    public float hp;
    public float speed;
    public int x;
    public int y;
}
