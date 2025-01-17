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

        // ������ ������ ���� �ĺ���ȣ
        [HideInInspector] public int itemNum = 0;

        protected override void Awake()
        {
            base.Awake();
            groundMove = false;
            itemNum = 0;
        }
    }
}

