using UnityEngine;
using MyUtil;
using TMPro;
using System.Collections;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public GameObject player;

        public bool GameOver { get; set; }

        public int NameNum { get; set; }

        protected override void Awake()
        {
            base.Awake();
            NameNum = 0;
            GameOver = false;
        }
    }
}

