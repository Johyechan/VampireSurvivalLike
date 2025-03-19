using UnityEngine;

namespace MyUtil
{
    public class DontDestroyManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}

