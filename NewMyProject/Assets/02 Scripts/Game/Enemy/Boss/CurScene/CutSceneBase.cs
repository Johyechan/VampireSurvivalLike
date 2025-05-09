using Enemy.Boss.Interface;
using System.Collections;
using UnityEngine;

namespace Enemy.Boss.CutScene
{
    public abstract class CutSceneBase : MonoBehaviour, ICutScene
    {
        public abstract void CutScenePlay();
    }
}

