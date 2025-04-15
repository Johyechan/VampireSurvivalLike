using Manager;
using UnityEngine;

namespace MyLight
{
    public class PlayerLight : MonoBehaviour
    {
        void Update()
        {
            transform.position = GameManager.Instance.player.transform.position;
        }
    }
}

