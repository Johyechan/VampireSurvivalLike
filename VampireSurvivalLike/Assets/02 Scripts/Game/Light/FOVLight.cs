using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyLight
{
    public class FOVLight : MonoBehaviour
    {
        void Update()
        {
            transform.position = GameManager.Instance.player.transform.position;
        }
    }
}

