using UnityEngine;

[CreateAssetMenu(fileName = "BackpackSO", menuName = "SO/BackpackSO", order = 0)]
public class BackpackSO : ScriptableObject
{
    public int[,] backpackArr;

    [SerializeField]
    private int[] backpackArrFlat = new int[54];

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
            for (int j = 0; j < 6; j++)
            {
                backpackArrFlat[i * 6 + j] = backpackArr[i, j];
            }
        }
    }
}
