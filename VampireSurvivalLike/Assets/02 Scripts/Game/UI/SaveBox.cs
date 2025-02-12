using Manager;
using MyUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveBox : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject _button;

    private UIController _myUIController;
    private UIController _buttonController;

    private RectTransform _rectTransform;

    [SerializeField] private float _delay;

    private float _interval = 0.3f;
    private float _resetTime = 0.0f;
    private float _doubleClickTime = -1.0f;

    private bool _isOneClicked = false;

    private void Awake()
    {
        _myUIController = GetComponent<UIController>();
        _buttonController = _button.GetComponent<UIController>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void OnDisable()
    {
        // 종료 버튼 만들고 게임을 아예 나가는 게 아닐 경우에만 실행되게 하기
        UIManager.Instance.MoveUI(_rectTransform, _rectTransform.position.x, -210, 0);
    }

    private void Update()
    {
        if(_isOneClicked)
        {
            _resetTime += Time.deltaTime;
            if (_resetTime > _interval)
            {
                ResetDoubleClickTime();
            }
        }
    }

    public void OpenBox()
    {
        UIManager.Instance.MoveUI(_rectTransform, _rectTransform.position.x, 15, _delay);
    }

    private void CloseBox()
    {
        UIManager.Instance.MoveUI(_rectTransform, _rectTransform.position.x, -210, _delay);
        _buttonController.ChangeAlpha(true, _delay);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if((Time.unscaledTime - _doubleClickTime) < _interval)
        {
            _isOneClicked = false;
            _doubleClickTime = -1.0f;
            CloseBox();
        }
        else
        {
            _doubleClickTime = Time.unscaledTime;
            _isOneClicked = true;
        }
    }

    private void ResetDoubleClickTime()
    {
        _doubleClickTime = -1.0f;
        _resetTime = 0.0f;
        _isOneClicked = false;
    }
}
