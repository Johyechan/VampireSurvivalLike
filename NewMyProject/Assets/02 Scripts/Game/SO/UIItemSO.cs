using MyUI.Struct;
using UnityEngine;

[CreateAssetMenu(fileName = "UIItemSO", menuName = "SO/UIItemSO", order = 0)]
public class UIItemSO : SOBase<UIItemSO>
{
    public ItemShape shape;

    public override UIItemSO DeepCopy()
    {
        UIItemSO so = CreateInstance<UIItemSO>();
        so.shape.shape = new Vector2Int[this.shape.shape.Length];
        for(int i = 0; i < this.shape.shape.Length; i++)
        {
            so.shape.shape[i] = this.shape.shape[i];
        }
        return so;
    }
}
