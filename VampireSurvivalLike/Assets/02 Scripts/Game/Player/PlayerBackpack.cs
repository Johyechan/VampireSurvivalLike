using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBackpack : MonoBehaviour
    {
        private int[,] _backpackArr = new int[9,6];
        public int[,] BackpackArr
        {
            get
            {
                return _backpackArr;
            }
            set
            {
                _backpackArr = value;
            }
        }
    }
}

