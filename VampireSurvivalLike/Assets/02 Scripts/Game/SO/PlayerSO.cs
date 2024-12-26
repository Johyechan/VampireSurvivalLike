using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSO", menuName = "SO/Player", order = 0)]
public class PlayerSO : ScriptableObject
{
    public float hp;
    public float speed;

    public int[,] backpackArr;

    [SerializeField]
    private int[] backpackArrFlat;

    private bool _isCalled;

    private void OnEnable()
    {
        if (backpackArr == null)
        {
            backpackArr = new int[9, 6];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    backpackArr[i, j] = backpackArrFlat[i * 6 + j];
                }
            }
        }

        if (_isCalled) return;

        if (backpackArr == null || backpackArrFlat.Length != 9 * 6)
        {
            backpackArrFlat = new int[9 * 6];
            _isCalled = true;
        }
    }

    public void SaveBackpackArr()
    {
        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                backpackArrFlat[i * 6 + j] = backpackArr[i, j];
            }
        }
    }
}
