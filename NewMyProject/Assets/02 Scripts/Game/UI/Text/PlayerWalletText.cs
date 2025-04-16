using Manager;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class PlayerWalletText : MonoBehaviour
{
    private TMP_Text _tmpText;

    private PlayerWallet _wallet;

    private void Awake()
    {
        _tmpText = GetComponent<TMP_Text>();
        _wallet = GameManager.Instance.player.GetComponent<PlayerWallet>();
    }

    void Update()
    {
        _tmpText.text = $"Money: {_wallet.CurrentMoney}$";
    }
}
