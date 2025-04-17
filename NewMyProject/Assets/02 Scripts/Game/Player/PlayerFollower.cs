using Manager;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    void Update()
    {
        transform.position = GameManager.Instance.player.transform.position;
    }
}
