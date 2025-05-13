using Enemy.Boss.Interface;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Enemy.Boss.CutScene
{
    public class RobotCutScene : CutSceneBase
    {
        [SerializeField] private GameObject _cutScene;
        [SerializeField] private Image _bossImage;
        [SerializeField] private GameObject _bossObj;
        [SerializeField] private TMP_Text _bossName;
        [SerializeField] private Transform _middleTarget;
        [SerializeField] private Transform _endTarget;

        public override void CutScenePlay()
        {
            Sequence animationSequence = DOTween.Sequence()
                .AppendCallback(() => Time.timeScale = 0)
                .AppendCallback(() => _cutScene.SetActive(true)).SetUpdate(true)
                .Append(_bossImage.DOFade(1, 1)).SetUpdate(true)
                .Append(_bossName.transform.DOMove(_middleTarget.position, 1)).SetUpdate(true)
                .Append(_bossName.transform.DOMove(_endTarget.position, 3)).SetUpdate(true)
                .AppendCallback(() => _cutScene.SetActive(false)).SetUpdate(true)
                .AppendCallback(() => _bossObj.SetActive(true)).SetUpdate(true)
                .AppendCallback(() => Time.timeScale = 1);
        }
    }
}

