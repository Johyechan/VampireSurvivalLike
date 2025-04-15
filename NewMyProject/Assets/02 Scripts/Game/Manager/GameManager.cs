using UnityEngine;
using MyUtil;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject player;

        public bool gameOver;

        public int nameNum = 0;
    }
}

