using UnityEngine;

namespace MyUtil
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool _isQuitting = false;

        private static T _instance;

        public static T Instance
        {
            get
            {
                if(_isQuitting)
                {
                    return null;
                }

                if(_instance == null)
                {
                    _instance = FindFirstObjectByType<T>();

                    if (_instance == null)
                    {
                        GameObject obj = new GameObject(typeof(T).Name);
                        _instance = obj.AddComponent<T>();
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if(_instance == null)
            {
                _instance = this as T;
            }
            else if(_instance != this)
            {
                Destroy(gameObject);
            }
        }

        private void OnApplicationQuit()
        {
            _isQuitting = true;
        }
    }
}

