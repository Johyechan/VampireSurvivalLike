using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int CurrentMoney {  get; set; }

    public bool UseMoney(int price)
    {
        if(CurrentMoney > price)
        {
            CurrentMoney -= price;
            return true;
        }

        return false;
    }

    public void AddMoney(int value)
    {
        CurrentMoney += value;
    }
}
