using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class GameManager : MonoSingleton<GameManager>
    {
        public GameObject player;

        public bool groundMove = false;

        public int x = 9;

        public int y = 6;

        // 아이템 구분을 위한 식별번호
        [HideInInspector] public int itemNum = 0;

        protected override void Awake()
        {
            base.Awake();
            groundMove = false;
            itemNum = 0;
        }
    }
}

