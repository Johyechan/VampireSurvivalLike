using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerBackpack : MonoBehaviour
    {
        private int _x;

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }

        private int _y;

        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }
    }
}

